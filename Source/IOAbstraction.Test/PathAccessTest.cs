//-------------------------------------------------------------------------------
// <copyright file="PathAccessTest.cs" company="Daniel Marbach">
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
    using System.Linq;
    using Fixtures;
    using Xunit;

    /// <summary>
    /// Tests the behavior of the <see cref="PathAccess"/>.
    /// </summary>
    public class PathAccessTest : IUseFixture<FileAccessFixture>
    {
        /// <summary>
        /// Gets or sets the fixture.
        /// </summary>
        /// <value>The fixture.</value>
        private FileAccessFixture Fixture { get; set; }

        /// <summary>
        /// Called on the test class just before each test method is run,
        /// passing the fixture data so that it can be used for the test.
        /// All test runs share the same instance of fixture data.
        /// </summary>
        /// <param name="data">The fixture data</param>
        public void SetFixture(FileAccessFixture data)
        {
            this.Fixture = data;
        }

        /// <summary>
        /// When the directory name of an existing directory is requested the
        /// directory name must be returned.
        /// </summary>
        [Fact]
        public void GetDirectoryName_MustReturnTheNameOfTheDirectory()
        {
            var testee = CreateTestee();

            string existingDirectory = this.Fixture.GetExistingEmptyDirectory();

            Assert.Equal(Path.GetDirectoryName(existingDirectory), testee.GetDirectoryName(existingDirectory));
        }

        /// <summary>
        /// When the file name of a directory is requested the directory name
        /// must be returned.
        /// </summary>
        [Fact]
        public void WithDirectory_GetFileName_MustReturnTheDirectoryName()
        {
            var testee = CreateTestee();

            string existingDirectory = this.Fixture.GetExistingEmptyDirectory();

            Assert.Equal(Path.GetFileName(existingDirectory), testee.GetFileName(existingDirectory));
        }

        /// <summary>
        /// When the file name of a file is requested the file name must be returned.
        /// </summary>
        [Fact]
        public void WithFile_GetFileName_MustReturnTheFileName()
        {
            var testee = CreateTestee();

            string existingFileName = this.Fixture.TestFiles.First().Value;

            Assert.Equal(Path.GetFileName(existingFileName), testee.GetFileName(existingFileName));
        }

        /// <summary>
        /// Withes the name of the directory_ get file name without extension_ must return the directory.
        /// </summary>
        [Fact]
        public void WithDirectory_GetFileNameWithoutExtension_MustReturnTheDirectoryName()
        {
            var testee = CreateTestee();

            string existingDirectory = this.Fixture.GetExistingEmptyDirectory();

            Assert.Equal(Path.GetFileNameWithoutExtension(existingDirectory), testee.GetFileNameWithoutExtension(existingDirectory));
        }

        /// <summary>
        /// When the file name without extensions of a file is requested the file name without extension must be returned.
        /// </summary>
        [Fact]
        public void WithFile_GetFileNameWithoutExtension_MustReturnTheFileNameWithoutExtension()
        {
            var testee = CreateTestee();

            string existingFileName = this.Fixture.TestFiles.First().Value;

            Assert.Equal(Path.GetFileNameWithoutExtension(existingFileName), testee.GetFileNameWithoutExtension(existingFileName));
        }

        // TODO: Combine, GetRandomFileName

        /// <summary>
        /// Creates the <see cref="PathAccess"/>.
        /// </summary>
        /// <returns>The newly created <see cref="PathAccess"/>.</returns>
        private static IPathAccess CreateTestee()
        {
            var testee = new PathAccess();

            return testee;
        }
    }
}