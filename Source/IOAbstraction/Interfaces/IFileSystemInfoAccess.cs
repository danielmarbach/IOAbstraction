//-------------------------------------------------------------------------------
// <copyright file="IFileSystemInfoAccess.cs" company="Daniel Marbach">
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

namespace IOAbstraction.Interfaces
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Security;

    /// <summary>
    /// Base interface definition for file system information access.
    /// </summary>
    public interface IFileSystemInfoAccess : ISerializable
    {
        /// <summary>
        /// Gets or sets the <see cref="System.IO.FileAttributes"/> of the current <see cref="IFileSystemInfoAccess"/>.
        /// </summary>
        /// <value><see cref="System.IO.FileAttributes"/> of the current <see cref="IFileSystemInfoAccess"/>.</value>
        /// <exception cref="FileNotFoundException">The specified file does not exist.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="IOException">The caller does not have the required permission.</exception>
        /// <exception cref="Refresh">The caller attempts to set an invalid file attribute.</exception>
        /// <exception cref="IDirectoryInfoAccess"><see cref="SecurityException"/> cannot initialize the data.</exception>
        FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the current <see cref="IFileSystemInfoAccess"/> object.
        /// </summary>
        /// <value>The creation date and time of the current <see cref="IFileSystemInfoAccess"/> object.</value>
        /// <exception cref="IOException"><see cref="IFileSystemInfoAccess.Refresh()"/> cannot initialize the data.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="System.PlatformNotSupportedException">The current operating system is not Microsoft Windows NT or later.</exception>
        DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the creation time, in coordinated universal time (UTC), of the
        /// current <see cref="IFileSystemInfoAccess"/> object.
        /// </summary>
        /// <value>The creation date and time in UTC format of the current <see cref="IFileSystemInfoAccess"/> object.</value>
        /// <exception cref="IOException"><see cref="IFileSystemInfoAccess.Refresh()"/> cannot initialize the data.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="System.PlatformNotSupportedException">The current operating system is not Microsoft Windows NT or later.</exception>
        DateTime CreationTimeUtc { get; set; }

        /// <summary>
        /// Gets a value indicating whether the file or directory exists.
        /// </summary>
        /// <value>true if the file or directory exists; otherwise, false.</value>
        bool Exists { get; }

        /// <summary>
        /// Gets the full path of the directory or file.
        /// </summary>
        /// <value>A string containing the full path.</value>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        string FullName { get; }

        /// <summary>
        /// Gets the name of the file for files. For directories, gets the name of the
        /// last directory in the hierarchy if a hierarchy exists. Otherwise, the Name
        /// property gets the name of the directory.
        /// </summary>
        /// <value>A string that is the name of the parent directory, the name of the last
        /// directory in the hierarchy, or the name of a file, including the file name
        /// extension.</value>
        string Name { get; }

        /// <summary>
        /// Refreshes the state of the object.
        /// </summary>
        /// <exception cref="IOException">A device such as a disk drive is not ready.
        /// </exception>
        void Refresh();

        /// <summary>
        /// Deletes a file or directory.
        /// </summary>
        /// <exception cref="IOException">The target file is open or memory-mapped on a computer running Microsoft Windows NT.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">The path is a directory.</exception>
        void Delete();
    }
}