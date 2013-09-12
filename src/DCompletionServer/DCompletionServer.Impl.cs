using System;
using System.Net.Sockets;


namespace DCompletionServer
{
	public partial class DCompletionServer
	{
		void HandleStreamInput(NetworkStream s)
		{
			switch (s.ReadByte ()) {

			}
		}
	}
}

