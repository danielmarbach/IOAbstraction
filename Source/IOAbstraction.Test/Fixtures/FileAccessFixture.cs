//-------------------------------------------------------------------------------
// <copyright file="FileAccessFixture.cs" company="Daniel Marbach">
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
    using System.IO;

    /// <summary>
    /// Fixture class which inherits from <see cref="DirectoryAccessFixture"/>
    /// and offers additional functionality for file access test.
    /// </summary>
    public sealed class FileAccessFixture : DirectoryAccessFixture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileAccessFixture"/> class.
        /// </summary>
        public FileAccessFixture()
        {
            this.TestFiles = this.EnsureTestFilesInDirectory(this.TestDirectory);
        }

        /// <summary>
        /// Gets the test files. The key of the dictionary is the file name and
        /// the value is the absolute path.
        /// </summary>
        /// <value>The test files.</value>
        public IDictionary<string, string> TestFiles { get; private set; }

        /// <summary>
        /// Compares the contents of the streams given.
        /// </summary>
        /// <param name="expected">The expected.</param><param name="actual">The actual.</param><returns>
        /// True if the stream contents are equal, else false.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
        public bool CompareStreamContents(Stream expected, Stream actual)
        {
            if (!expected.CanRead)
            {
                throw new ArgumentException("Expected stream is not readable");
            }

            if (!actual.CanRead)
            {
                throw new ArgumentException("Actual stream is not readable");
            }

            int i = 0;
            int j = 0;
            while (i == j && i != -1)
            {
                i = expected.ReadByte();
                j = actual.ReadByte();
            }

            return i == j;
        }

        /// <summary>
        /// Copies the input stream to the output stream.
        /// </summary>
        /// <param name="input">The input stream.</param><param name="output">The output stream.</param><exception cref="ArgumentNullException"><paramref name="input" /> or <paramref name="output" /> are null.
        /// </exception><exception cref="ArgumentException"><paramref name="input" />is not readable or <paramref name="output" /> is
        /// not writable.</exception>
        public void CopyStream(Stream input, Stream output)
        {
            // assert these are the right kind of streams
            if (input == null)
            {
                throw new ArgumentNullException("input", "Input stream was null");
            }

            if (output == null)
            {
                throw new ArgumentNullException("output", "Output stream was null");
            }

            if (!input.CanRead)
            {
                throw new ArgumentException("Input stream must support CanRead");
            }

            if (!output.CanWrite)
            {
                throw new ArgumentException("Output stream must support CanWrite");
            }

            // skip if the input stream is empty (if seeking is supported)
            if (input.CanSeek)
            {
                if (input.Length == 0)
                {
                    return;
                }
            }

            // copy it
            const int Size = 4096;
            byte[] bytes = new byte[Size];
            int numBytes;
            while ((numBytes = input.Read(bytes, 0, Size)) > 0)
            {
                output.Write(bytes, 0, numBytes);
            }
        }
    }
}