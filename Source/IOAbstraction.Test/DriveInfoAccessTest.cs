//-------------------------------------------------------------------------------
// <copyright file="DriveInfoAccessTest.cs" company="Daniel Marbach">
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

namespace IOAbstraction.Test
{
    using Fixtures;
    using Xunit;

    /// <summary>
    /// Tests the behavior of the <see cref="DriveInfoAccess"/>.
    /// </summary>
    public class DriveInfoAccessTest : IUseFixture<DriveAccessFixture>
    {
        /// <summary>
        /// Gets or sets the fixture.
        /// </summary>
        /// <value>The fixture.</value>
        private DriveAccessFixture Fixture { get; set; }

        /// <summary>
        /// Called on the test class just before each test method is run,
        /// passing the fixture data so that it can be used for the test.
        /// All test runs share the same instance of fixture data.
        /// </summary>
        /// <param name="data">The fixture data</param>
        public void SetFixture(DriveAccessFixture data)
        {
            this.Fixture = data;
        }

        /// <summary>
        /// When the drives are queried the <see cref="DriveInfoAccess.GetDrives"/> must return all available
        /// drives.
        /// </summary>
        [Fact(Skip = "Currently no good idea how to test")]
        public void GetDrives_MustReturnAllAvailableDrives()
        {
            var testee = this.CreateTestee();
        }

        /// <summary>
        /// The available free space must represent the free space of the
        /// underlying drive info.
        /// </summary>
        [Fact]
        public void AvailableFreeSpace_MustRepresentTheFreeSpaceOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.AvailableFreeSpace, testee.AvailableFreeSpace);
        }

        /// <summary>
        /// The drive format must represent the drive format of the underlying drive info.
        /// </summary>
        [Fact]
        public void DriveFormat_MustRepresentTheDriveFormatOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.DriveFormat, testee.DriveFormat);
        }

        /// <summary>
        /// The drive type must represent the drive type of the underlying drive info.
        /// </summary>
        [Fact]
        public void DriveType_MustRepresentTheDriveTypeOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.DriveType, testee.DriveType);
        }

        /// <summary>
        /// The ready state of the drive must represent the ready state of the underlying drive info.
        /// </summary>
        [Fact]
        public void IsReady_MustRepresentTheIsReadyOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.IsReady, testee.IsReady);
        }

        /// <summary>
        /// The name must represent the name of the underlying drive info.
        /// </summary>
        [Fact]
        public void Name_MustRepresentTheNameOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.Name, testee.Name);
        }

        /// <summary>
        /// The root directory must represent the name of the underlying drive info.
        /// </summary>
        [Fact]
        public void RootDirectory_MustRepresentTheRootDirectoryOfUnderlyingDriveInfo()
        {
            var testee = this.CreateTestee();

            Assert.Equal(this.Fixture.RootDrive.RootDirectory.ToString(), testee.RootDirectory.ToString());
        }
        
        /// <summary>
        /// Creates the <see cref="DriveInfoAccess"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="DriveInfoAccess"/>.</returns>
        private IDriveInfoAccess CreateTestee()
        {
            var testee = new DriveInfoAccess(this.Fixture.RootDrive);

            return testee;
        }
    }
}