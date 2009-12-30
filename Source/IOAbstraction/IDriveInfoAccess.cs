//-------------------------------------------------------------------------------
// <copyright file="IDriveInfoAccess.cs" company="Daniel Marbach">
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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// Interface which simplifies the access to directory info.
    /// </summary>
    public interface IDriveInfoAccess : ISerializable
    {
        /// <summary>
        /// Gets the amount of available free space on a drive.
        /// </summary>
        /// <value>The amount of free space available on the drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        long AvailableFreeSpace { get; }

        /// <summary>
        /// Gets the total amount of free space available on a drive.
        /// </summary>
        /// <value>The total free space available on a drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        long TotalFreeSpace { get; }

        /// <summary>
        /// Gets the total size of storage space on a drive.
        /// </summary>
        /// <value>The total size of the drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        long TotalSize { get; }

        /// <summary>
        /// Gets the name of a drive.
        /// </summary>
        /// <value>The name of the drive.</value>
        string Name { get; }

        /// <summary>
        /// Retrieves the drive names of all logical drives on a computer.
        /// </summary>
        /// <returns>An enumerable of type <see cref="IDriveInfoAccess"/> that represents the logical drives on a computer.</returns>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "The drive info access shall have the same interface as DriveInfo.")]
        IEnumerable<IDriveInfoAccess> GetDrives();
    }
}