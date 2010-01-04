//-------------------------------------------------------------------------------
// <copyright file="FileAccessTest.cs" company="Daniel Marbach">
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
    using Interfaces;
    using Xunit;
    using FileAccess = FileAccess;

    /// <summary>
    /// Tests the behavior of the <see cref="FileAccess"/>.
    /// </summary>
    public class FileAccessTest : IUseFixture<FileAccessFixture>
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
        /// When an existing file is deleted and the delete method is called the
        /// file must be deleted afterward.
        /// </summary>
        [Fact]
        public void WhenExistingFileIsDeleted_Delete_TheFileMustBeDeleted()
        {
            var testee = CreateTestee();

            string existingFile = this.Fixture.GetExistingFile();
            testee.Delete(existingFile);

            Assert.False(File.Exists(existingFile));
        }

        /// <summary>
        /// When a none existing file is deleted the call to delete must
        /// actually do nothing.
        /// </summary>
        [Fact]
        public void WhenNotExistingFileIsDeleted_Delete_TheFileMustNotBePresent()
        {
            var testee = CreateTestee();

            string notExistingFile = this.Fixture.GetNotExistingFile();
            testee.Delete(notExistingFile);

            Assert.False(File.Exists(notExistingFile));
        }

        /// <summary>
        /// When a stream writer is requested from a given text file a stream
        /// writer decorator must be returned.
        /// </summary>
        [Fact]
        public void WhenStreamWriterIsRequested_CreateText_TheStreamWriterMustExist()
        {
            var testee = CreateTestee();

            string existingFile = this.Fixture.TestFiles.First().Value;

            using (IStreamWriterAccess streamWriter = testee.CreateText(existingFile))
            {
                Assert.NotNull(streamWriter);   

                streamWriter.Close();
            }
        }

        /// <summary>
        /// Creates the <see cref="IOAbstraction.FileAccess"/>.
        /// </summary>
        /// <returns>A newly created <see cref="IOAbstraction.FileAccess"/>.</returns>
        private static IFileAccess CreateTestee()
        {
            var testee = new FileAccess();

            return testee;
        }
    }
}