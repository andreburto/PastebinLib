PastebinLib.cs
----------------------------------------------------------------------

VERSION:
1.0

ABOUT:
A wrapper that works with the PasteBin API (http://pastebin.com/api)
written in C# and targeting the .NET 4.0 runtime. It may be posible to
use another version. Be aware that PastebinLib.Pastebin uses the
System.Web library which is not part of the "Client Profile" for .NET
according to Visual C# 2010 Express.

Please note that Languages.txt, Privacy.txt, and Expires.txt need to
be compiled into the assembly for PastebinLib.PastebinOptions to work,
but not for PastebinLib.Pastebin if you want to use the latter on its
own.

TO DO:
As far as I can tell this version of the library works with all
listed functions on Pastebin API page, but I would like to experiment
to see if editing is possible at some point.

This software is provided as-is under the MIT License and is not
supported by the developer in any way.

----------------------------------------------------------------------

Copyright (c) 2014-2015 Andrew Burton

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.