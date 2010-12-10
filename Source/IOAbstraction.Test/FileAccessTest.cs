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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
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
        /// When the source file is copied into an non existing file the source file must be copied.
        /// </summary>
        [Fact]
        public void WhenFileIsCopiedIntoNonExistingFile_Copy_MustCopyTheFile()
        {
            var testee = CreateTestee();

            var sourceFile = this.Fixture.GetExistingFile();
            var destinationFile = this.Fixture.GetNotExistingFile();

            testee.Copy(sourceFile, destinationFile);

            Assert.True(this.Fixture.FileEquals(sourceFile, destinationFile));
        }

        /// <summary>
        /// When the source file is copied into an existing file an exception must be thrown.
        /// </summary>
        [Fact]
        public void WhenFileIsCopiedIntoExistingFile_Copy_MustThrowException()
        {
            var testee = CreateTestee();

            var sourceFile = this.Fixture.GetExistingFile();
            var destinationFile = this.Fixture.GetExistingFile();

            Assert.Throws<IOException>(() => testee.Copy(sourceFile, destinationFile));
        }

        /// <summary>
        /// When the source file is copied into an existing file with overwrite set to false an exception must be
        /// thrown.
        /// </summary>
        [Fact]
        public void WhenFileIsCopiedIntoExistingFileWithOverwriteFalse_CopyOverwrite_MustThrowException()
        {
            var testee = CreateTestee();

            var sourceFile = this.Fixture.GetExistingFile();
            var destinationFile = this.Fixture.GetExistingFile();

            Assert.Throws<IOException>(() => testee.Copy(sourceFile, destinationFile, false));
        }

        /// <summary>
        /// When the source file is copied into an existing file with overwrite set to true the source file must be
        /// copied.
        /// </summary>
        [Fact]
        public void WhenFileIsCopiedIntoExistingFileWithOverwriteTrue_CopyOverwrite_MustNotThrowException()
        {
            var testee = CreateTestee();

            var sourceFile = this.Fixture.GetExistingFile();
            var destinationFile = this.Fixture.GetExistingFile();

            Assert.DoesNotThrow(() => testee.Copy(sourceFile, destinationFile, true));
            Assert.True(this.Fixture.FileEquals(sourceFile, destinationFile));
        }

        /// <summary>
        /// When a source file is copied into a destination file which does not exist the source file must be copied.
        /// </summary>
        [Fact]
        public void WhenFileIsCopiedIntoNonExistingFile_CopyOverwrite_MustCopyTheFile()
        {
            var testee = CreateTestee();

            var sourceFile = this.Fixture.GetExistingFile();
            var destinationFile = this.Fixture.GetNotExistingFile();

            testee.Copy(sourceFile, destinationFile, false);

            Assert.True(this.Fixture.FileEquals(sourceFile, destinationFile));
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

        [Fact]
        public void WriteAllLines_MustWriteProvidedLinesToFile()
        {
            var content = new List<string> { "Item1", "Item2" };

            var testee = CreateTestee();
           
            var nonExistingFile = this.Fixture.GetNotExistingFile();

            testee.WriteAllLines(nonExistingFile, content);

            string actual = File.ReadAllText(nonExistingFile);

            StringBuilder sb = new StringBuilder();
            content.ForEach(line => sb.AppendLine(line));

            Assert.Equal(sb.ToString(), actual);
        }

        [Fact]
        public void WriteAllLines_WithEncoding_MustWriteProvidedLinesToFile()
        {
            var content = new List<string> { "Item1\u0168", "Item2\u0168" };

            var testee = CreateTestee();

            var nonExistingFile = this.Fixture.GetNotExistingFile();

            testee.WriteAllLines(nonExistingFile, content, Encoding.Unicode);

            string actual = File.ReadAllText(nonExistingFile, Encoding.Unicode);

            StringBuilder sb = new StringBuilder();
            content.ForEach(line => sb.AppendLine(line));

            Assert.Equal(sb.ToString(), actual);
        }

        /// <summary>
        /// When all text is written into a file the file must contain the written text.
        /// </summary>
        [Fact]
        public void WriteAllText_MustWriteProvidedTextToFile()
        {
            const string TestFileContent = "TestContent";

            var testee = CreateTestee();

            var nonExistingFile = this.Fixture.GetNotExistingFile();

            testee.WriteAllText(nonExistingFile, TestFileContent);

            string actual = File.ReadAllText(nonExistingFile);

            Assert.Equal(TestFileContent, actual);
        }

        [Fact]
        public void WriteAllBytes_MustWriteProvidedBytesToFile()
        {
            const string TestFileContent = "TestContent";

            var testee = CreateTestee();

            var nonExistingFile = this.Fixture.GetNotExistingFile();

            testee.WriteAllBytes(nonExistingFile, Encoding.ASCII.GetBytes(TestFileContent));

            string actual = File.ReadAllText(nonExistingFile);

            Assert.Equal(TestFileContent, actual);
        }

        [Fact]
        public void Open_WithPathAndMode_MustOpenFile()
        {
            this.AssertFileOpened((testee, nonExistingFile) => testee.Open(nonExistingFile, FileMode.CreateNew));
        }

        [Fact]
        public void Open_WithPathAndModeAndFileAccess_MustOpenFile()
        {
            this.AssertFileOpened((testee, nonExistingFile) => testee.Open(nonExistingFile, FileMode.CreateNew, System.IO.FileAccess.ReadWrite));
        }

        [Fact]
        public void Open_With_MustOpenFile()
        {
            this.AssertFileOpened((testee, nonExistingFile) => testee.Open(nonExistingFile, FileMode.CreateNew, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite));
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

        /// <summary>
        /// Asserts that a given file path was correctly opened.
        /// </summary>
        /// <param name="open">The open function.</param>
        private void AssertFileOpened(Func<IFileAccess, string, Stream> open)
        {
            var testee = CreateTestee();

            var nonExistingFile = this.Fixture.GetNotExistingFile();

            var memoryStream = new MemoryStream();
            var expectedStream = new MemoryStream();

            var stream = open(testee, nonExistingFile);
            
            this.Fixture.CopyStream(stream, memoryStream);
            stream.Close();

            stream = File.Open(nonExistingFile, FileMode.Open);
            this.Fixture.CopyStream(stream, expectedStream);
            stream.Close();

            Assert.True(this.Fixture.CompareStreamContents(expectedStream, memoryStream));
        }
    }
}