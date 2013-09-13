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
		Clear = 1,
		ParseDirectories = 2,
		PreresolveUFCS = 3,

		WaitForParseFinish = 4,
		GetParseProgress = 5,
		StopParseProcess = 6,

		// Completion options
		GetCompletionOption=7,
		SetCompletionOption=8,

		// Editing
		OpenFile=9,
		ReleaseFile=10,

		InsertText=11,
		RemoveText=12,
		ReplaceText=13,

		// Completion
		RequestCompletionItems=14,
		GetItemDescription=15,

		GetLastError = 16,
	}
}

