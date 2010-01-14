//-------------------------------------------------------------------------------
// <copyright file="StreamWriterAccessTest.cs" company="Daniel Marbach">
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
    using Bases;
    using Xunit;

    /// <summary>
    /// Tests the behavior of the <see cref="StreamWriterAccess"/>.
    /// </summary>
    public sealed class StreamWriterAccessTest : TextWriterAccessTest<StreamWriter, StreamWriterAccess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamWriterAccessTest"/> class.
        /// </summary>
        public StreamWriterAccessTest()
        {
            this.TestDataStream = new MemoryStream();
            this.Writer = new StreamWriter(this.TestDataStream);
            this.Testee = new StreamWriterAccess(this.Writer);
        }

        /// <summary>
        /// When the default value of AutoFlush is requested the value must
        /// represent the AutoFlush of the underlying stream writer.
        /// </summary>
        [Fact]
        public void WhenDefault_AutoFlush_MustReturnAutoFlushOfUnderlyingStreamWriter()
        {
            Assert.Equal(this.Writer.AutoFlush, this.Testee.AutoFlush);
        }

        /// <summary>
        /// When the AutoFlush is assigned the AutoFlush must represent the
        /// value of the underlying stream writer.
        /// </summary>
        [Fact]
        public void WhenAutoFlushIsAssigned_AutoFlush_MustReturnAutoFlushOfUnderlyingStreamWriter()
        {
            this.Writer.AutoFlush = true;

            Assert.Equal(this.Writer.AutoFlush, this.Testee.AutoFlush);
        }

        /// <summary>
        /// When the BaseStream is requested the value must represent the
        /// BaseStream of the underlying writer.
        /// </summary>
        [Fact]
        public void WhenDefault_BaseStream_MustReturnBaseStreamOfUnderlyingStreamWriter()
        {
            Assert.Equal(this.Writer.BaseStream, this.Testee.BaseStream);
        }
    }
}