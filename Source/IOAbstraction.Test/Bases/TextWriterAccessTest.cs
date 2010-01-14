//-------------------------------------------------------------------------------
// <copyright file="TextWriterAccessTest.cs" company="Daniel Marbach">
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

namespace IOAbstraction.Test.Bases
{
    using System.IO;
    using Xunit;

    /// <summary>
    /// Serves as base class for all TextWriterAccessTests.
    /// </summary>
    /// <typeparam name="TWriter">The type of the writer.</typeparam>
    /// <typeparam name="TTestee">The type of the testee.</typeparam>
    public abstract class TextWriterAccessTest<TWriter, TTestee>
        where TWriter : TextWriter
        where TTestee : TextWriterAccess
    {
        /// <summary>
        /// Gets or sets the test data stream.
        /// </summary>
        /// <value>The test data stream.</value>
        protected Stream TestDataStream { get; set; }

        /// <summary>
        /// Gets or sets the writer.
        /// </summary>
        /// <value>The writer.</value>
        protected TWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets the testee.
        /// </summary>
        /// <value>The testee.</value>
        protected TTestee Testee { get; set; }

        [Fact]
        public void Encoding_MustRepresentEncodingFromUnderlyingTextWriter()
        {
            Assert.Equal(this.Writer.Encoding, this.Testee.Encoding);
        }

        [Fact]
        public void FormatProvider_MustRepresentFormatProviderFromUnderlyingTextWriter()
        {
            Assert.Equal(this.Writer.FormatProvider, this.Testee.FormatProvider);
        }

        [Fact]
        public void WhenDefault_NewLine_MustReturnNewLineFromUnderlyingTextWriter()
        {
            Assert.Equal(this.Writer.NewLine, this.Testee.NewLine);
        }

        [Fact]
        public void WhenAssigned_NewLine_MustReturnNewLineFromUnderlyingTextWriter()
        {
            const string NewLine = "Test";

            this.Writer.NewLine = NewLine;

            Assert.Equal(this.Writer.NewLine, this.Testee.NewLine);
        }

        [Fact]
        public void WhenABooleanIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(true));

            Assert.Equal(4, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenACharIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write('c'));

            Assert.Equal(1, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenACharBufferIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(new[] { 'c', 'c' }));

            Assert.Equal(2, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenASubArrayOfCharBufferIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(new[] { 'c', 'c', 'c' }, 1, 2));

            Assert.Equal(2, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenADecimalIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(decimal.Zero));

            Assert.Equal(1, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenADoubleIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(double.Epsilon));

            Assert.Equal(21, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenAFloatIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(float.Epsilon));

            Assert.Equal(12, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenAIntIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(int.MaxValue));

            Assert.Equal(10, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenALongIntIsWritten_Write_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(long.MaxValue));

            Assert.Equal(19, this.TestDataStream.Length);
        }

        [Fact]
        public void WhenObjectIsWritten_Wirte_MustWriteItViaUnderlyingTextWriterToStream()
        {
            this.Testee.AutoFlush(self => self.Write(new object()));

            Assert.Equal(13, this.TestDataStream.Length);
        }
    }
}