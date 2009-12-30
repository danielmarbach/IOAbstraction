//-------------------------------------------------------------------------------
// <copyright file="IDirectoryAccess.cs" company="Daniel Marbach">
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
    using System.IO;

    /// <summary>
    /// Abstraction layer which simplifies access to directories.
    /// </summary>
    public interface IDirectoryAccess
    {
        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path"> The path to test.</param>
        /// <returns><c>true</c> if path refers to an existing directory; otherwise, <c>false</c>.</returns>
        bool Exists(string path);

        /// <summary>
        /// Creates all directories and subdirectories as specified by path.
        /// </summary>
        /// <param name="path">
        /// The directory path to create.
        /// </param>
        /// <returns>
        /// A <see cref="IOException"/> as specified by path.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">The directory specified by path is read-only.
        /// </exception>
        /// <exception cref="ArgumentException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentNullException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.  -or- path is prefixed with, or contains only
        /// a colon character (:).</exception>
        /// <exception cref="PathTooLongException">path is null.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="NotSupportedException">The specified path is invalid (for
        /// example, it is on an unmapped drive).</exception>
        /// <exception cref="IDirectoryInfoAccess">path contains a colon character (:) that is not part of a drive label ("C:\").</exception>
        IDirectoryInfoAccess CreateDirectory(string path);

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories in the
        /// directory.
        /// </summary>
        /// <param name="path">
        /// The name of the directory to remove.
        /// </param>
        /// <param name="recursive">
        /// <c>true</c> to remove directories, subdirectories, and files in path;
        /// otherwise, <c>false</c>.
        /// </param>
        /// <exception cref="IOException">A file with the same name and location specified
        /// by path exists.  -or- The directory specified by path is read-only, or
        /// recursive is false and path is not an empty directory.  -or- The directory is
        /// the application's current working directory.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path does not exist
        /// or could not be found.  -or- The specified path is invalid (for example, it is
        /// on an unmapped drive).</exception>
        void Delete(string path, bool recursive);

        /// <summary>
        /// Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">
        /// The name of the empty directory to remove. This directory must be writable or empty.
        /// </param>
        /// <exception cref="IOException">A file with the same name and location specified
        /// by path exists.  -or- The directory specified by path is read-only, or
        /// recursive is false and path is not an empty directory.  -or- The directory is
        /// the application's current working directory.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path does not exist
        /// or could not be found.  -or- The specified path is invalid (for example, it is
        /// on an unmapped drive).</exception>
        void Delete(string path);

        /// <summary>
        /// Returns the names of files in the specified directory.
        /// </summary>
        /// <param name="path">
        /// The directory from which to retrieve the files.
        /// </param>
        /// <returns>
        /// An enumerable of file names in the specified directory.
        /// </returns>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for
        /// example, it is on an unmapped drive).</exception>
        IEnumerable<string> GetFiles(string path);

        /// <summary>
        /// Returns the names of files in the specified directory that match the specified search pattern.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchPattern">The search string to match against the names of
        /// files in path. The parameter cannot end in two periods ("..") or contain two
        /// periods ("..") followed by System.IO.Path.DirectorySeparatorChar or
        /// System.IO.Path.AltDirectorySeparatorChar, nor can it contain any of the
        /// characters in System.IO.Path.InvalidPathChars.</param>
        /// <returns>An enumerable containing the names of files in the specified directory
        /// that match the specified search pattern.</returns>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for
        /// example, it is on an unmapped drive).</exception>
        IEnumerable<string> GetFiles(string path, string searchPattern);

        /// <summary>
        /// Returns the names of files in the specified directory that match the specified
        /// search pattern, using a value to determine whether to search subdirectories.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <param name="searchPattern">The search string to match against the names of
        /// files in path. The parameter cannot end in two periods ("..") or contain two
        /// periods ("..") followed by System.IO.Path.DirectorySeparatorChar or
        /// System.IO.Path.AltDirectorySeparatorChar, nor can it contain any of the
        /// characters in System.IO.Path.InvalidPathChars.</param>
        /// <param name="searchOption">One of the System.IO.SearchOption values that
        /// specifies whether the search operation should include all subdirectories or
        /// only the current directory.</param>
        /// <returns>
        /// An enumerable containing the names of files in the specified directory that
        /// match the specified search pattern.
        /// </returns>
        /// <exception cref="IOException">path is a file name.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the
        /// required permission.</exception>
        /// <exception cref="ArgumentException">path is a zero-length string, contains only
        /// white space, or contains one or more invalid characters as defined by
        /// System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for
        /// example, it is on an unmapped drive).</exception>
        IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption);

        /// <summary>
        /// Gets the names of subdirectories in the specified directory.
        /// </summary>
        /// <param name="path">The path for which an array of subdirectory names is
        /// returned.</param>
        /// <returns>An enumerable of type String containing the names of subdirectories in
        /// path.</returns>
        /// <exception cref="System.UnauthorizedAccessException">The caller does not have
        /// the required permission.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string,
        /// contains only white space, or contains one or more invalid characters as
        /// defined by System.IO.Path.InvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.PathTooLongException">The specified path, file name,
        /// or both exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">The specified path is
        /// invalid (for example, it is on an unmapped drive).</exception>
        IEnumerable<string> GetDirectories(string path);
    }
}