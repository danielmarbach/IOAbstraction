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
    using System.Collections.Generic;

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
    }
}