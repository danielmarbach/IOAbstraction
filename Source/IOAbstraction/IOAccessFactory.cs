//-------------------------------------------------------------------------------
// <copyright file="IOAccessFactory.cs" company="Daniel Marbach">
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
    /// The IO access factory which implements <see cref="IIOAccessFactory"/>.
    /// </summary>
    public class IOAccessFactory : IIOAccessFactory
    {
        /// <summary>
        /// Creates the directory access layer.
        /// </summary>
        /// <returns>An instance implementing <see cref="IDirectoryAccess"/>.</returns>
        public IDirectoryAccess CreateDirectoryAccess()
        {
            return new DirectoryAccess();
        }

        /// <summary>
        /// Creates the file access layer.
        /// </summary>
        /// <returns>An instance implementing <see cref="IFileAccess"/>.</returns>
        public IFileAccess CreateFileAccess()
        {
            return new FileAccess();
        }

        /// <summary>
        /// Creates the path access layer.
        /// </summary>
        /// <returns>An instance implementing <see cref="IPathAccess"/>.</returns>
        public IPathAccess CreatePathAccess()
        {
            return new PathAccess();
        }

        /// <summary>
        /// Creates the file info access.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <returns>An instance implementing <see cref="IFileInfoAccess"/>.</returns>
        public IFileInfoAccess CreateFileInfo(FileInfo fileInfo)
        {
            return new FileInfoAccess(fileInfo);
        }

        /// <summary>
        /// Creates the file info access.
        /// </summary>
        /// <param name="pathToFile">The file path.</param>
        /// <returns>
        /// An instance implementing <see cref="IFileInfoAccess"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="pathToFile"/> is null.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required
        /// permission.</exception>
        /// <exception cref="ArgumentException">The file name is empty, contains only white
        /// spaces, or contains invalid characters.</exception>
        /// <exception cref="UnauthorizedAccessException">Access to
        /// <paramref name="pathToFile"/> is denied.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="pathToFile"/> contains
        /// a colon (:) in the middle of the string.</exception>
        public IFileInfoAccess CreateFileInfo(string pathToFile)
        {
            return new FileInfoAccess(new FileInfo(pathToFile));
        }

        /// <summary>
        /// Creates the directory info access.
        /// </summary>
        /// <param name="directoryInfo">The directory info.</param>
        /// <returns>An instance implementing <see cref="IDirectoryInfoAccess"/>.</returns>
        public IDirectoryInfoAccess CreateDirectoryInfo(DirectoryInfo directoryInfo)
        {
            return new DirectoryInfoAccess(directoryInfo);
        }

        /// <summary>
        /// Creates the directory info access.
        /// </summary>
        /// <param name="pathToDirectory">The directory path.</param>
        /// <returns>
        /// An instance implementing <see cref="IDirectoryInfoAccess"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">path is null.</exception>
        /// <exception cref="SecurityException">The caller does not have the required
        /// permission.</exception>
        /// <exception cref="ArgumentException">path contains invalid characters.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both
        /// exceed the system-defined maximum length. For example, on Windows-based
        /// platforms, paths must be less than 248 characters, and file names must be less
        /// than 260 characters. The specified path, file name, or both are too long.
        /// </exception>
        public IDirectoryInfoAccess CreateDirectoryInfo(string pathToDirectory)
        {
            return new DirectoryInfoAccess(new DirectoryInfo(pathToDirectory));
        }

        /// <summary>
        /// Creates the drive info.
        /// </summary>
        /// <param name="driveInfo">The drive info.</param>
        /// <returns>An instance implementing <see cref="IDriveInfoAccess"/>.</returns>
        public IDriveInfoAccess CreateDriveInfo(DriveInfo driveInfo)
        {
            return new DriveInfoAccess(driveInfo);
        }

        /// <summary>
        /// Creates the drive info access.
        /// </summary>
        /// <param name="driveName">A valid drive path or drive letter. This can be either
        /// uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <exception cref="ArgumentNullException">The drive letter cannot be null.
        /// </exception>
        /// <exception cref="ArgumentException">The first letter of 
        /// <paramref name="driveName"/> is not an uppercase or lowercase letter from 'a'
        /// to 'z'.  -or- 
        /// <paramref name="driveName"/> does not refer to a valid drive.</exception>
        /// <returns>An instance implementing <see cref="IDriveInfoAccess"/>.</returns>
        public IDriveInfoAccess CreateDriveInfo(string driveName)
        {
            return new DriveInfoAccess(new DriveInfo(driveName));
        }
    }
}