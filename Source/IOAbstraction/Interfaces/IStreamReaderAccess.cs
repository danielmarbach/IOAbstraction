//-------------------------------------------------------------------------------
// <copyright file="IStreamReaderAccess.cs" company="Daniel Marbach">
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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Interface for stream reader implementations.
    /// </summary>
    public interface IStreamReaderAccess : ITextReaderAccess
    {
        /// <summary>
        /// Returns the underlying stream.
        /// </summary>
        /// <value>The underlying stream.</value>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
    "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Original comment from framework API.")]
        Stream BaseStream { get; }

        /// <summary>
        /// Gets the current character encoding that the current 
        /// <see cref="StreamReader"/> object is using.
        /// </summary>
        /// <value>The current character encoding used by the current reader.
        /// The value can be different after the first call to any
        /// Overload:System.IO.StreamReader.Read method of
        /// System.IO.StreamReader, since encoding autodetection is not done
        /// until the first call to a Overload:System.IO.StreamReader.Read
        /// method.</value>
        Encoding CurrentEncoding { get; }

        /// <summary>
        /// Gets a value that indicates whether the current stream position is at the end of the stream.
        /// </summary>
        /// <value>true if the current stream position is at the end of the stream; otherwise false.</value>
        /// <exception cref="ObjectDisposedException"> The underlying stream has been disposed.</exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules",
            "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Original comment from framework API.")]
        bool EndOfStream { get; }

        /// <summary>
        /// Allows a <see cref="StreamReader"/> object to discard its current data.
        /// </summary>
        void DiscardBufferedData();
    }
}