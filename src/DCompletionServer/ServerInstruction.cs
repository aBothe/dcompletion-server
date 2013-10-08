//
// ServerInstruction.cs
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

namespace DCompletionServer
{
	public enum ServerInstruction : byte
	{
		Invalid = 0,

		// Parse low-level
		ClearParseCaches = 1,
		ParseDirectories = 2,
		PreresolveUFCS = 3, // Does a client really need to call this explicitly?

		WaitForParseFinish = 4,
		GetParseProgress = 5,
		StopParseProcess = 6,

		GetCachedDirectories=18,

		// Completion options
		GetCompletionOption=7,
		SetCompletionOption=8,

		// File Meta Operations
		CreateFile=23,
		/// <summary>
		/// Open a file for editing.
		/// </summary>
		OpenFile=9,
		ReloadFile=17,
		ReleaseFile=10,
		RenameFile=21,
		GetFileName=22,

		// Editing
		SetFileText=19,
		GetFileText=20,
		/// <summary>
		/// Insert text into a file at a specific position.
		/// </summary>
		InsertText=11,
		/// <summary>
		/// Remove text from a file.
		/// </summary>
		RemoveText=12,
		/// <summary>
		/// Replace text in a file.
		/// </summary>
		ReplaceText=13,

		// Completion
		RequestCompletionContext=25, // For getting abstract language info about a location in the code - like expression/type/in a string/comment? etc.
		RequestCompletionItems=14,
		GetItemDescription=15,

		// Resolution
		FindSymbolReferences=24,

		GetLastError = 16,
	}
}

