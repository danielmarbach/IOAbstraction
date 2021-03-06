//-------------------------------------------------------------------------------
// <copyright file="IStreamWriterAccess.cs" company="Daniel Marbach">
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

namespace IOAbstraction.Interfaces
{
    using System.IO;

    /// <summary>
    /// Interface for stream writers.
    /// </summary>
    public interface IStreamWriterAccess : ITextWriterAccess
    {
        /// <summary>
        /// Gets or sets a value indicating whether the 
        /// <see cref="System.IO.StreamWriter"/>will flush its buffer to the
        /// underlying stream after every call to
        /// <see cref="System.IO.StreamWriter.Write(System.Char)"/>.
        /// </summary>
        /// <value><see langword="true"/> to force 
        /// <see cref="System.IO.StreamWriter"/> to flush its buffer; otherwise,
        /// <see langword="false"/>.</value>
        bool AutoFlush { get; set; }

        /// <summary>
        /// Gets the underlying stream that interfaces with a backing store.
        /// </summary>
        /// <value>The stream this StreamWriter is writing to.</value>
        Stream BaseStream { get; }
    }
}