//-------------------------------------------------------------------------------
// <copyright file="DirectoryAccessTest.cs" company="Daniel Marbach">
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
    using System.IO;
    using Fixtures;
    using Xunit;

    /// <summary>
    /// Tests the behavior of the <see cref="DirectoryAccess"/>.
    /// </summary>
    public class DirectoryAccessTest : IUseFixture<DirectoryAccessFixture>
    {
        /// <summary>
        /// Gets or sets the fixture.
        /// </summary>
        /// <value>The fixture.</value>
        private DirectoryAccessFixture Fixture { get; set; }

        /// <summary>
        /// Called on the test class just before each test method is run,
        /// passing the fixture data so that it can be used for the test.
        /// All test runs share the same instance of fixture data.
        /// </summary>
        /// <param name="data">The fixture data</param>
        public void SetFixture(DirectoryAccessFixture data)
        {
            this.Fixture = data;
        }

        /// <summary>
        /// When the directory is existent the call to 
        /// <see cref="DirectoryAccess.Exists"/> must return 
        /// <see langword="true"/>.
        /// </summary>
        [Fact]
        public void WhenDirectoryIsExistent_Exists_MustReturnTrue()
        {
            var testee = CreateTestee();

            Assert.True(testee.Exists(this.Fixture.TestDirectory));
        }

        /// <summary>
        /// When the directory is not existent the call to 
        /// <see cref="DirectoryAccess.Exists"/> must return 
        /// <see langword="false"/>.
        /// </summary>
        [Fact]
        public void WhenDirectoryIsNotExistent_Exists_MustReturnFalse()
        {
            var testee = CreateTestee();

            string notExistingDirectory = this.Fixture.GetNotExistingDirectory();

            Assert.False(testee.Exists(notExistingDirectory));
        }

        /// <summary>
        /// When the directory is not existing the call to 
        /// <see cref="DirectoryAccess.CreateDirectory"/>  must return
        /// information about the directory.
        /// </summary>
        [Fact]
        public void WhenDirectoryIsNotExistent_CreateDirectory_MustReturnInformationAboutCreatedDirectory()
        {
            var testee = CreateTestee();

            string notExistingDirectory = this.Fixture.GetNotExistingDirectory();

            IDirectoryInfoAccess directoryInfo = testee.CreateDirectory(notExistingDirectory);

            Assert.NotNull(directoryInfo);
            Assert.True(directoryInfo.Exists);
            Assert.Equal(notExistingDirectory, directoryInfo.FullName);
        }

        /// <summary>
        /// When the directory is existing the call to 
        /// <see cref="DirectoryAccess.CreateDirectory"/> must return
        /// information about the existing directory. 
        /// </summary>
        [Fact]
        public void WhenDirectoryIsExistent_CreateDirectory_MustReturnInformationAboutExistingDirectory()
        {
            var testee = CreateTestee();

            string existingDirectory = this.Fixture.GetExistingEmptyDirectory();

            IDirectoryInfoAccess directoryInfo = testee.CreateDirectory(existingDirectory);

            Assert.NotNull(directoryInfo);
            Assert.True(directoryInfo.Exists);
            Assert.Equal(existingDirectory, directoryInfo.FullName);
        }

        /// <summary>
        /// When the directory is existent and empty the call to 
        /// <see cref="DirectoryAccess.Delete(string, bool)"/> must delete the
        /// directory.
        /// </summary>
        [Fact]
        public void WhenDirectoryIsExistentAndEmpty_DeleteNonRecursively_MustDeleteTheDirectory()
        {
            const bool Recursively = true;

            var testee = CreateTestee();

            string existingEmptyDirectory = this.Fixture.GetExistingEmptyDirectory();

            testee.Delete(existingEmptyDirectory, !Recursively);

            Assert.False(Directory.Exists(existingEmptyDirectory));
        }

        /// <summary>
        /// Whens the directory is existent and not empty the call to 
        /// <see cref="DirectoryAccess.Delete(string, bool)"/> must throw an 
        /// <see cref="IOException"/>.
        /// </summary>
        [Fact]
        public void WhenDirectoryIsExistentAndNotEmpty_DeleteNonRecursively_MustThrowNotEmpty()
        {
            const bool Recursively = true;

            var testee = CreateTestee();

            string existingNotEmptyDirectory = this.Fixture.GetExistingNotEmptyDirectory();

            Assert.Throws<IOException>(() => testee.Delete(existingNotEmptyDirectory, !Recursively));
        }

        /// <summary>
        /// When the directory is existing and empty the call to 
        /// <see cref="DirectoryAccess.Delete(string, bool)"/> must delete the
        /// directory.
        /// </summary>
        /// <remarks>The recursive parameter must be set to <see langword="true"/>.</remarks>
        [Fact]
        public void WhenDirectoryIsExistentAndEmpty_DeleteRecursively_MustDeleteTheDirectory()
        {
            const bool Recursively = true;

            var testee = CreateTestee();

            string existingEmptyDirectory = this.Fixture.GetExistingEmptyDirectory();

            testee.Delete(existingEmptyDirectory, Recursively);

            Assert.False(Directory.Exists(existingEmptyDirectory)); 
        }

        /// <summary>
        /// Whens the directory is existent and not empty the call to 
        /// <see cref="DirectoryAccess.Delete(string, bool)"/> must delete the
        /// directory.
        /// </summary>
        /// <remarks>The recursive parameter must be set to <see langword="true"/>.</remarks>
        [Fact]
        public void WhenDirectoryIsExistentAndNotEmpty_DeleteRecursively_MustDeleteTheDirectory()
        {
            const bool Recursively = true;

            var testee = CreateTestee();

            string existingNotEmptyDirectory = this.Fixture.GetExistingNotEmptyDirectory();

            testee.Delete(existingNotEmptyDirectory, Recursively);

            Assert.False(Directory.Exists(existingNotEmptyDirectory));
        }

        /// <summary>
        /// Creates the <see cref="DirectoryAccess"/>.
        /// </summary>
        /// <returns>A newly created <see cref="DirectoryAccess"/>.</returns>
        private static IDirectoryAccess CreateTestee()
        {
            var testee = new DirectoryAccess();

            return testee;
        }
    }
}