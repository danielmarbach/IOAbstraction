//-------------------------------------------------------------------------------
// <copyright file="StreamWriterAccess.cs" company="Daniel Marbach">
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

namespace IOAbstraction
{
    using System.IO;
    using Interfaces;

    /// <summary>
    /// <see cref="StreamWriter"/> decorator.
    /// </summary>
    public class StreamWriterAccess : TextWriterAccess, IStreamWriterAccess
    {
        /// <summary>
        /// Holds the decorated <see cref="StreamWriter"/>
        /// </summary>
        private readonly StreamWriter decoratedStreamWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamWriterAccess"/> class.
        /// </summary>
        /// <param name="streamWriter">The stream writer.</param>
        public StreamWriterAccess(StreamWriter streamWriter) : base(streamWriter)
        {
            this.decoratedStreamWriter = streamWriter;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the 
        /// <see cref="System.IO.StreamWriter"/>will flush its buffer to the
        /// underlying stream after every call to
        /// <see cref="System.IO.StreamWriter.Write(System.Char)"/>.
        /// </summary>
        /// <value><see langword="true"/> to force 
        /// <see cref="System.IO.StreamWriter"/> to flush its buffer; otherwise,
        /// <see langword="false"/>.</value>
        public bool AutoFlush
        {
            get
            {
                return this.decoratedStreamWriter.AutoFlush;
            }

            set
            {
                this.decoratedStreamWriter.AutoFlush = value;
            }
        }

        /// <summary>
        /// Gets the underlying stream that interfaces with a backing store.
        /// </summary>
        /// <value>The stream this <see cref="StreamWriter"/> is writing to.</value>
        public Stream BaseStream
        {
            get
            {
                return this.decoratedStreamWriter.BaseStream;
            }
        }
    }
}