//-------------------------------------------------------------------------------
// <copyright file="DriveInfoAccess.cs" company="Daniel Marbach">
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
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Wrapper class which simplifies the access to drive information.
    /// </summary>
    [Serializable]
    public sealed class DriveInfoAccess : IDriveInfoAccess
    {
        /// <summary>
        /// The wrapped drive info.
        /// </summary>
        private readonly DriveInfo driveInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriveInfoAccess"/> class.
        /// </summary>
        /// <param name="driveInfo">The drive info.</param>
        public DriveInfoAccess(DriveInfo driveInfo)
        {
            this.driveInfo = driveInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriveInfoAccess"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        private DriveInfoAccess(SerializationInfo info, StreamingContext context)
        {
        }

        /// <summary>
        /// Gets the amount of available free space on a drive.
        /// </summary>
        /// <value>The amount of free space available on the drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long AvailableFreeSpace
        {
            get { return this.driveInfo.AvailableFreeSpace; }
        }

        /// <summary>
        /// Gets the total amount of free space available on a drive.
        /// </summary>
        /// <value>The total free space available on a drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long TotalFreeSpace
        {
            get { return this.driveInfo.TotalFreeSpace; }
        }

        /// <summary>
        /// Gets the total size of storage space on a drive.
        /// </summary>
        /// <value>The total size of the drive, in bytes.</value>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        public long TotalSize
        {
            get { return this.driveInfo.TotalSize; }
        }

        /// <summary>
        /// Gets the name of a drive.
        /// </summary>
        /// <value>The name of the drive.</value>
        public string Name
        {
            get { return this.driveInfo.Name; }
        }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with
        /// the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The 
        /// <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with
        /// data. 
        /// </param><param name="context">The destination (see 
        /// <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this
        /// serialization. 
        /// </param><exception cref="T:System.Security.SecurityException">The caller does
        /// not have the required permission. 
        /// </exception>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)this.driveInfo).GetObjectData(info, context);
        }

        /// <summary>
        /// Retrieves the drive names of all logical drives on a computer.
        /// </summary>
        /// <returns>An enumerable of type <see cref="IDriveInfoAccess"/> that represents the logical drives on a computer.</returns>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        public IEnumerable<IDriveInfoAccess> GetDrives()
        {
            return DriveInfo.GetDrives().Select(info => new DriveInfoAccess(info)).OfType<IDriveInfoAccess>();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            return this.driveInfo.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.driveInfo.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.driveInfo.ToString();
        }
    }
}