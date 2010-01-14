//-------------------------------------------------------------------------------
// <copyright file="PathAccess.cs" company="Daniel Marbach">
//   Copyright (c) 2009 Daniel Marbach
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace IOAbstraction
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using Interfaces;
    using log4net;

    /// <summary>
    /// Wrapper class which simplifies access to paths.
    /// </summary>
    public class PathAccess : IPathAccess
    {
        /// <summary>
        /// The logger of this class
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Returns the directory information for the specified path string..
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>A System.String containing directory information for path, or null if
        /// path denotes a root directory, is the empty string (""), or is null. Returns
        /// System.String.Empty if path does not contain directory information.</returns>
        /// <exception cref="ArgumentException">The path parameter contains invalid
        /// characters, is empty, or contains only white spaces.</exception>
        /// <exception cref="PathTooLongException">The path parameter is longer than the system-defined maximum length.</exception>
        public string GetDirectoryName(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Getting directory name of {0}.", path);
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        /// Returns the file name and extension of the specified path string.
        /// </summary>
        /// <param name="path">The path string from which to obtain the file name and
        /// extension.</param>
        /// <returns>A System.String consisting of the characters after the last directory
        /// character in path. If the last character of path is a directory or volume
        /// separator character, this method returns System.String.Empty. If path is null,
        /// this method returns null.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars().</exception>
        public string GetFileName(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Getting file name and extension of {0}.", path);
            return Path.GetFileName(path);
        }

        /// <summary>
        /// Returns the file name of the specified path string without the extension.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>A System.String containing the string returned by <see cref="IPathAccess.GetFileName"/>, minus the last period (.) and all characters following it.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> contains one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars().</exception>
        public string GetFileNameWithoutExtension(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Getting file name without extension of {0}.", path);
            return Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// Combines two path strings.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns>A string containing the combined paths. If one of the specified paths
        /// is a zero-length string, this method returns the other path. If <paramref name="path2"/> contains
        /// an absolute path, this method returns <paramref name="path2"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="path1"/> or <paramref name="path2"/> contain one or more of the invalid characters defined in System.IO.Path.GetInvalidPathChars().</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path1"/> or <paramref name="path2"/> is null.</exception>
        public string Combine(string path1, string path2)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Combining {0} with {1}.", path1, path2);
            return Path.Combine(path1, path2);
        }

        /// <summary>
        /// Returns a random folder name or file name.
        /// </summary>
        /// <returns>A random folder name or file name.</returns>
        public string GetRandomFileName()
        {
            Log.Debug("Getting random file name.");
            return Path.GetRandomFileName();
        }
    }
}