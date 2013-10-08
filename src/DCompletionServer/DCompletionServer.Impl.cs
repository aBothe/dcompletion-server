using System;
using System.Net.Sockets;


namespace DCompletionServer
{
	public partial class DCompletionServer
	{
		void HandleStreamInput(NetworkStream s)
		{
			switch (s.ReadByte ()) {
				case ServerInstruction.ClearParseCaches:
					break;
				case ServerInstruction.ParseDirectories:
					break;
				case ServerInstruction.PreresolveUFCS:
					break;
				case ServerInstruction.WaitForParseFinish:
					break;
				case ServerInstruction.GetParseProgress:
					break;
				case ServerInstruction.StopParseProcess:
					break;

				case ServerInstruction.GetCompletionOption:
					break;
				case ServerInstruction.SetCompletionOption:
					break;

				case ServerInstruction.OpenFile:
					break;
				case ServerInstruction.ReleaseFile:
					break;

				case ServerInstruction.InsertText:
					break;
				case ServerInstruction.RemoveText:
					break;
				case ServerInstruction.ReplaceText:
					break;

				case ServerInstruction.RequestCompletionItems:
					break;
				case ServerInstruction.GetItemDescription:
					break;
			}
		}
	}
}

