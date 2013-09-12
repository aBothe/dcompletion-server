//
// Program.cs
//
// Author:
//       Alexander Bothe <info@alexanderbothe.com>
//
// Copyright (c) 2013 Alexander Bothe
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace DCompletionServer
{
	public partial class DCompletionServer
	{
		#region Properties
		const int port = 13600;
		TcpListener tcp;

		int InstanceId=0;
		int NumClients = 0;
		const int LastClientDisconnectedTimeout = 15;
		const int LastClientDisconnectedIntervalMult = 1;
		#endregion

		#region Constructor/Init
		public void Init(string[] args)
		{
			Console.WriteLine ("DCompletionServer written by Alexander Bothe");
			Console.WriteLine ();

			tcp = new TcpListener(IPAddress.Any, port);
			tcp.ExclusiveAddressUse = true;
		}

		public void Run()
		{
			tcp.Start ();

			Console.WriteLine("Listening on port "+port.ToString());

			while (tcp.Server.IsBound)
				ThreadPool.QueueUserWorkItem (clientThread, tcp.AcceptTcpClient());
		}

		public void Stop()
		{
			tcp.Stop ();
		}
		#endregion

		/// <summary>
		/// Threaded routine which cares about connection low-levels.
		/// </summary>
		/// <param name="s">The incoming tcp client connection.</param>
		void clientThread(object s)
		{
			Interlocked.Increment (ref NumClients);
			var id = Interlocked.Increment (ref InstanceId);

			var cl = s as TcpClient;
			Console.WriteLine ("Client #{0} connected from {1}", InstanceId, cl.Client.RemoteEndPoint);

			var stream = cl.GetStream ();
			while (cl.Connected) {
				try{
					HandleStreamInput(stream);
				}catch(Exception ex) {
					Console.WriteLine ("#{0} Exception: {1}", id, ex.Message);
					Console.WriteLine ("#{0} Stacktrace:\r\n{1}", id, ex.StackTrace);
				}
			}

			Console.WriteLine ("Client #{0} disconnected ({1})", InstanceId, cl.Client.RemoteEndPoint);

			if (Interlocked.Decrement (ref NumClients) < 1) {
				Console.WriteLine ("Last client disconnected!");
				Console.WriteLine ("Waiting {0}s until shutdown...", LastClientDisconnectedTimeout*LastClientDisconnectedIntervalMult);

				for (int i = LastClientDisconnectedTimeout; i >= 0; i++) {
					Console.WriteLine ("{0}s remaining",i*LastClientDisconnectedIntervalMult);
					Thread.Sleep (1000 * LastClientDisconnectedIntervalMult);

					if (NumClients > 0)
						return;

					Stop ();
				}
			}
		}
	}
}
