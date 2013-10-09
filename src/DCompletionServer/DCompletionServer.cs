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
		const int port = 53600;
		UdpClient udp;

		const int waitTimeout = 30000;
		#endregion

		#region Constructor/Init
		public void Init(string[] args)
		{
			Console.WriteLine ("DCompletionServer written by Alexander Bothe");
			Console.WriteLine ();

			udp = new UdpClient{ ExclusiveAddressUse = true };
			udp.Connect(IPAddress.Any, port);
		}

		bool stop;
		public void Run()
		{
			stop = false;
			var ep = new IPEndPoint(IPAddress.Any, 0);

			Console.WriteLine("Listening on port "+port.ToString());

			while (!stop && udp.Client.IsBound) {
				var asyn = udp.BeginReceive ((ar) => {
					var data = udp.EndReceive (ar,ref ep);
					ThreadPool.QueueUserWorkItem (clientThread, new Tuple<IPEndPoint, byte[]>(ep, data));
				}, null);

				if (!asyn.AsyncWaitHandle.WaitOne (waitTimeout)) {
					Console.WriteLine ("Timeout - no package received during the last {0} seconds!\nShutting down!", waitTimeout/1000);
					Stop ();
					break;
				}
			}
		}

		public void Stop()
		{
			stop = true;
			udp.Close ();
		}
		#endregion

		/// <summary>
		/// Threaded routine which cares about connection low-levels.
		/// </summary>
		/// <param name="s">The incoming tcp client connection.</param>
		void clientThread(object s)
		{
			var tup = s as Tuple<IPEndPoint, byte[]>;
		}
	}
}
