//-------------------------------------------------------------------------------
// <copyright file="FileAccess.cs" company="Daniel Marbach">
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Text;
    using Interfaces;
    using log4net;

    /// <summary>
    /// Wrapper class which simplifies the access to the file layer.
    /// </summary>
    public class FileAccess : IFileAccess
    {
        /// <summary>
        /// The logger of this class
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Deletes the specified file. An exception is not thrown if the specified file
        /// does not exist.
        /// </summary>
        /// <param name="path">The name of the file to be deleted.</param>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid,
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">The specified file is in use.</exception>
        /// <exception cref="NotSupportedException">path is in an invalid format.
        /// </exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.  -or- path is a directory.  -or- path specified a
        /// read-only file.
        /// </exception>
        public void Delete(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Deleting file {0}", path);
            File.Delete(path);
        }

        /// <summary>
        /// Creates or opens a file for writing UTF-8 encoded text.
        /// </summary>
        /// <param name="path">The file to be opened for writing.</param>
        /// <returns>A <see cref="System.IO.StreamWriter"/> that writes to the specified
        /// file using UTF-8 encoding.</returns>
        /// <exception cref="System.UnauthorizedAccessException">The caller does not have
        /// the required permission.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.ArgumentException"> path is a zero-length string, contains only white space, or contains one or more invalid characters as defined by System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="System.NotSupportedException">path is in an invalid format.</exception>
        public IStreamWriterAccess CreateText(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Creating file {0}", path);
            return new StreamWriterAccess(File.CreateText(path));
        }

        /// <summary>
        /// Gets the <see cref="FileAttributes"/> of the file on the path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The <see cref="FileAttributes"/> of the file on the path</returns>
        /// <exception cref="ArgumentException">path is empty, contains only white spaces,
        /// or contains invalid characters.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="NotSupportedException">path is in an invalid format.
        /// </exception>
        /// <exception cref="FileNotFoundException">path represents a file and is invalid,
        /// such as being on an unmapped drive, or the file cannot be found.</exception>
        /// <exception cref="DirectoryNotFoundException">path represents a directory and is
        /// invalid, such as being on an unmapped drive, or the directory cannot be found.
        /// </exception>
        public FileAttributes GetAttributes(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Getting attributes on file {0}.", path);
            return File.GetAttributes(path);
        }

        /// <summary>
        /// Sets the date and time that the specified file was last written to.
        /// </summary>
        /// <param name="path">The file for which to set the date and time information.
        /// </param>
        /// <param name="lastWriteTime">A <see cref="System.DateTime"/> containing the
        /// value to set for the last write date and time of path. This value is expressed
        /// in local time.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="lastWriteTime"/> specifies a value outside the range of dates
        /// or times permitted for this operation.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string,
        /// contains only white space, or contains one or more invalid characters as
        /// defined by System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.PathTooLongException">The specified path, file name,
        /// or both exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="System.IO.FileNotFoundException">The specified path was not
        /// found.</exception>
        /// <exception cref="System.UnauthorizedAccessException">The caller does not have
        /// the required permission.</exception>
        /// <exception cref="System.NotSupportedException">path is in an invalid format.
        /// </exception>
        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Setting last write time of {0} to {1}", path, lastWriteTime);
            File.SetLastWriteTime(path, lastWriteTime);
        }

        /// <summary>
        /// Sets the specified <see cref="FileAttributes"/> of the file on the specified
        /// path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileAttributes">The desired <see cref="FileAttributes"/>, such as
        /// Hidden, ReadOnly, Normal, and Archive.</param>
        /// <exception cref="ArgumentException">path is empty, contains only white spaces,
        /// contains invalid characters, or the file attribute is invalid.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="NotSupportedException">path is in an invalid format.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid,
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
        /// <exception cref="UnauthorizedAccessException">path specified a file that is
        /// read-only. -or- This operation is not supported on the current platform.  -or-
        /// path specified a directory. -or- The caller does not have the required
        /// permission.</exception>
        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Setting attributes {0} on file {1}.", fileAttributes, path);
            File.SetAttributes(path, fileAttributes);
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">The file to check.</param>
        /// <returns>true if the caller has the required permissions and path contains the
        /// name of an existing file; otherwise, false. This method also returns false if
        /// path is null, an invalid path, or a zero-length string. If the caller does not
        /// have sufficient permissions to read the specified file, no exception is thrown
        /// and the method returns false regardless of the existence of path.</returns>
        public bool Exists(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Checking if file {0} exists.", path);
            return File.Exists(path);
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then
        /// closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>An enumerable containing the contents of the file.</returns>
        /// <exception cref="ArgumentException"> path is a zero-length string, contains
        /// only white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException"> path is null.</exception>
        /// <exception cref="PathTooLongException"> The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"> The specified path is invalid
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException"> An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException"> This operation is not supported
        /// on the current platform.  -or- path specified a directory.  -or- The caller
        /// does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"> The file specified in path was not
        /// found.</exception>
        /// <exception cref="NotSupportedException"> path is in an invalid format.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public IEnumerable<byte> ReadAllBytes(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading bytes of file {0}.", path);
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>An enumerable containing all lines of the file.</returns>
        /// <exception cref="ArgumentException"> path is a zero-length string, contains
        /// only white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException"> path is null.</exception>
        /// <exception cref="PathTooLongException"> The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"> The specified path is invalid
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException"> An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException"> This operation is not supported
        /// on the current platform.  -or- path specified a directory.  -or- The caller
        /// does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"> The file specified in path was not
        /// found.</exception>
        /// <exception cref="NotSupportedException"> path is in an invalid format.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public IEnumerable<string> ReadAllLines(string path, Encoding encoding)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all lines of file {0} with encoding {1}.", path, encoding);
            return File.ReadAllLines(path, encoding);
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>An enumerable containing all lines of the file.</returns>
        /// <exception cref="ArgumentException"> path is a zero-length string, contains
        /// only white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException"> path is null.</exception>
        /// <exception cref="PathTooLongException"> The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"> The specified path is invalid
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException"> An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException"> This operation is not supported
        /// on the current platform.  -or- path specified a directory.  -or- The caller
        /// does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"> The file specified in path was not
        /// found.</exception>
        /// <exception cref="NotSupportedException"> path is in an invalid format.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public IEnumerable<string> ReadAllLines(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all lines of file {0}.", path);
            return File.ReadAllLines(path);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>A string containing all lines of the file.</returns>
        /// <exception cref="ArgumentException"> path is a zero-length string, contains
        /// only white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException"> path is null.</exception>
        /// <exception cref="PathTooLongException"> The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"> The specified path is invalid
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException"> An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException"> This operation is not supported
        /// on the current platform.  -or- path specified a directory.  -or- The caller
        /// does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"> The file specified in path was not
        /// found.</exception>
        /// <exception cref="NotSupportedException"> path is in an invalid format.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public string ReadAllText(string path, Encoding encoding)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all text of file {0} with encoding {1}.", path, encoding);
            return File.ReadAllText(path, encoding);
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        /// <exception cref="ArgumentException"> path is a zero-length string, contains
        /// only white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException"> path is null.</exception>
        /// <exception cref="PathTooLongException"> The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"> The specified path is invalid
        /// (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException"> An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException"> This operation is not supported
        /// on the current platform.  -or- path specified a directory.  -or- The caller
        /// does not have the required permission.</exception>
        /// <exception cref="FileNotFoundException"> The file specified in path was not
        /// found.</exception>
        /// <exception cref="NotSupportedException"> path is in an invalid format.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public string ReadAllText(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all text of file {0}.", path);
            return File.ReadAllText(path);
        }
    }
}