//-------------------------------------------------------------------------------
// <copyright file="DirectoryAccessFixture.cs" company="Daniel Marbach">
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

namespace IOAbstraction.Test.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Disposable fixture for <see cref="DirectoryAccess"/> tests.
    /// </summary>
    public class DirectoryAccessFixture : IDisposable
    {
        /// <summary>
        /// The prefix for the test directory name.
        /// </summary>
        private const string TestDirectoryNamePrefix = "TestDirectory";

        /// <summary>
        /// The prefix for all test files.
        /// </summary>
        private const string TestFileNamePrefix = "TestFile";

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryAccessFixture"/> class.
        /// </summary>
        public DirectoryAccessFixture()
        {
            this.TestDirectoryName = string.Format(CultureInfo.InvariantCulture, "{0}{1}", TestDirectoryNamePrefix, this.GetRandomName());
            this.TestDirectory = Path.Combine(Path.GetTempPath(), this.TestDirectoryName);

            this.EnsureDirectoryNotExistent(this.TestDirectory);
            this.EnsureDirectoryExistent(this.TestDirectory);
        }

        /// <summary>
        /// Gets the full path to the test directory.
        /// </summary>
        /// <value>The full path to the test directory.</value>
        public string TestDirectory { get; private set; }

        /// <summary>
        /// Gets the name of the test directory.
        /// </summary>
        /// <value>The name of the test directory.</value>
        public string TestDirectoryName { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.EnsureDirectoryNotExistent(this.TestDirectory);
        }

        /// <summary>
        /// Ensures that the directory is not existent.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void EnsureDirectoryNotExistent(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }

        /// <summary>
        /// Ensures that the directory is existent.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void EnsureDirectoryExistent(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// Ensures that the file is not existent.
        /// </summary>
        /// <param name="file">The file to check.</param>
        public void EnsureFileNotExistent(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Ensures that the file is existent.
        /// </summary>
        /// <remarks>The created file contains text with the absolute file name.
        /// </remarks>
        /// <param name="file">The file that is checked.</param>
        public void EnsureFileExistent(string file)
        {
            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.Write(file);
                }
            }
        }

        /// <summary>
        /// Ensures that the test files are present in the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns>A dictionary containing the test files. The key is the test
        /// file name and the value is the absolute path to the test file.
        /// </returns>
        public virtual IDictionary<string, string> EnsureTestFilesInDirectory(string directory)
        {
            this.EnsureDirectoryExistent(directory);

            var testFile1 = this.Combine(directory, this.GetRandomFileName());
            var testFile2 = this.Combine(directory, this.GetRandomFileName());
            var testFile3 = this.Combine(directory, this.GetRandomFileName());

            var testFiles = new Dictionary<string, string>
                                {
                                     { Path.GetFileName(testFile1), testFile1 },
                                     { Path.GetFileName(testFile2), testFile2 },
                                     { Path.GetFileName(testFile3), testFile3 },
                                };

            foreach (KeyValuePair<string, string> keyValuePair in testFiles)
            {
                this.EnsureFileExistent(keyValuePair.Value);
            }

            return testFiles;
        }

        /// <summary>
        /// Gets the random name without extension.
        /// </summary>
        /// <returns>The random name without extension.</returns>
        public string GetRandomName()
        {
            return Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }

        /// <summary>
        /// Gets a randomized file name.
        /// </summary>
        /// <returns>A randomized file name.</returns>
        public string GetRandomFileName()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", TestFileNamePrefix, Path.GetRandomFileName());
        }

        /// <summary>
        /// Combines to paths
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns>The combined path.</returns>
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        /// <summary>
        /// Gets a not existing sub directory of <see cref="TestDirectory"/>.
        /// </summary>
        /// <returns>The full path to a not existing directory.</returns>
        public string GetNotExistingDirectory()
        {
            string notExistingDirectory = this.Combine(this.TestDirectory, this.GetRandomName());
            this.EnsureDirectoryNotExistent(notExistingDirectory);
            return notExistingDirectory;
        }

        /// <summary>
        /// Gets an existing sub directory of <see cref="TestDirectory"/>.
        /// </summary>
        /// <returns>The full path to an existing directory.</returns>
        public string GetExistingEmptyDirectory()
        {
            string existingDirectory = this.Combine(this.TestDirectory, this.GetRandomName());
            this.EnsureDirectoryExistent(existingDirectory);
            return existingDirectory;
        }

        /// <summary>
        /// Gets the existing not empty directory.
        /// </summary>
        /// <returns>The path to the not empty directory.</returns>
        public string GetExistingNotEmptyDirectory()
        {
            string existingDirectory = this.GetExistingEmptyDirectory();
            this.EnsureTestFilesInDirectory(existingDirectory);
            return existingDirectory;
        }

        /// <summary>
        /// Gets a not existing file as member of <see cref="TestDirectory"/>.
        /// </summary>
        /// <returns>The full path to a not existing file.</returns>
        public string GetNotExistingFile()
        {
            string notExistingFile = this.Combine(this.TestDirectory, this.GetRandomFileName());
            this.EnsureFileNotExistent(notExistingFile);
            return notExistingFile;
        }

        /// <summary>
        /// Gets an existing file as member of <see cref="TestDirectory"/>.
        /// </summary>
        /// <returns>The full path to an existing file.</returns>
        public string GetExistingFile()
        {
            string existingDirectory = this.Combine(this.TestDirectory, this.GetRandomFileName());
            this.EnsureFileExistent(existingDirectory);
            return existingDirectory;
        }
    }
}