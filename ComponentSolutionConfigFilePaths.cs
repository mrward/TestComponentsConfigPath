//
// ComponentSolutionConfigFilePaths.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2015 Xamarin Inc. (http://xamarin.com)
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
//
using System;
using System.Collections.Generic;
using System.IO;

namespace ComponentsConfigPathTests
{
	public static class ComponentSolutionConfigFilePaths
	{
		public static IEnumerable<string> GetDirectories (string solutionDirectory)
		{
			string rootDirectory = Path.Combine (solutionDirectory, ".components");

			while (rootDirectory != null) {
				yield return rootDirectory;
				rootDirectory = Path.GetDirectoryName (rootDirectory);
			}

			string appDataDirectory = GetAppDataDirectory ();
			if (!String.IsNullOrEmpty (appDataDirectory)) {
				yield return Path.Combine (appDataDirectory, "Xamarin", "Components");
			}
		}

		static string GetAppDataDirectory ()
		{
			if (Platform.IsMac) {
				string home = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				return Path.Combine (home, "Library", "Preferences");
			} else {
				return Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData);
			}
		}
	}
}

