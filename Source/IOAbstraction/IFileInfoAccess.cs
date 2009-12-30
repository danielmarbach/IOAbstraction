//-------------------------------------------------------------------------------
// <copyright file="IFileInfoAccess.cs" company="Daniel Marbach">
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
    using System.IO;
    using System.Security;

    /// <summary>
    /// Interface which simplifies the access to the file info.
    /// </summary>
    public interface IFileInfoAccess : IFileSystemInfoAccess
    {
        /// <summary>
        /// Gets an instance of the parent directory.
        /// </summary>
        /// <value>A <see cref="IDirectoryInfoAccess"/> object representing the parent
        /// directory of this file.</value>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        IDirectoryInfoAccess Directory { get; }

        /// <summary>
        /// Gets a string representing the directory's full path.
        /// </summary>
        /// <value>A string representing the directory's full path.</value>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentNullException">null was passed in for the directory name.</exception>
        string DirectoryName { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the current file is read only.
        /// </summary>
        /// <value>
        /// true if the current file is read only; otherwise, false.
        /// </value>
        /// <exception cref="FileNotFoundException">The file described by the current 
        /// <see cref="IFileInfoAccess"/> object could not be found</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The file described by the current
        /// <see cref="IFileInfoAccess"/> object is read-only.  -or- This operation is not
        /// supported on the current platform.  -or- The caller does not have the required
        /// permission.</exception>
        bool IsReadOnly { get; set; }

        /// <summary>
        /// Gets the size, in bytes, of the current file.
        /// </summary>
        /// <value>The size of the current file in bytes.</value>
        /// <exception cref="IOException"><see cref="IFileSystemInfoAccess.Refresh()"/> cannot update the state of the file or directory.</exception>
        /// <exception cref="FileNotFoundException">The file does not exist. -or- The Length property is called for a directory.</exception>
        long Length { get; }
    }
}