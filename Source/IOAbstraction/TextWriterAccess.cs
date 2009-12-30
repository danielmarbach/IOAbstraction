//-------------------------------------------------------------------------------
// <copyright file="TextWriterAccess.cs" company="Daniel Marbach">
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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Security.Permissions;
    using System.Text;

    /// <summary>
    /// <see cref="TextWriter"/> decorator.
    /// </summary>
    public abstract class TextWriterAccess : TextWriter, ITextWriterAccess
    {
        /// <summary>
        /// Holds the decorated <see cref="TextWriter"/>.
        /// </summary>
        private readonly TextWriter decoratedTextWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextWriterAccess"/> class.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        protected TextWriterAccess(TextWriter textWriter)
        {
            this.decoratedTextWriter = textWriter;
        }

        /// <summary>
        /// When overridden in a derived class, returns the <see cref="T:System.Text.Encoding"/> in which the output is written.
        /// </summary>
        /// <value></value>
        /// <returns>The Encoding in which the output is written.</returns>
        public override Encoding Encoding
        {
            get
            {
                return this.decoratedTextWriter.Encoding;
            }
        }

        /// <summary>
        /// Gets an object that controls formatting.
        /// </summary>
        /// <value></value>
        /// <returns>An <see cref="T:System.IFormatProvider"/> object for a
        /// specific culture, or the formatting of the current culture if no
        /// other culture is specified.</returns>
        public override IFormatProvider FormatProvider
        {
            get
            {
                return this.decoratedTextWriter.FormatProvider;
            }
        }

        /// <summary>
        /// Gets or sets the line terminator string used by the current TextWriter.
        /// </summary>
        /// <value></value>
        /// <returns>The line terminator string for the current TextWriter.</returns>
        public override string NewLine
        {
            get
            {
                return this.decoratedTextWriter.NewLine;
            }

            set
            {
                this.decoratedTextWriter.NewLine = value;
            }
        }

        /// <summary>
        /// Closes the current writer and releases any system resources associated with the writer.
        /// </summary>
        public override void Close()
        {
            this.decoratedTextWriter.Close();
        }

        /// <summary>
        /// Clears all buffers for the current writer and causes any buffered data to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            this.decoratedTextWriter.Flush();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.decoratedTextWriter.ToString();
        }

        /// <summary>
        /// Writes the text representation of a Boolean value to the text stream.
        /// </summary>
        /// <param name="value">The Boolean to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(bool value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes a character to the text stream.
        /// </summary>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes a character array to the text stream.
        /// </summary>
        /// <param name="buffer">The character array to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char[] buffer)
        {
            this.decoratedTextWriter.Write(buffer);
        }

        /// <summary>
        /// Writes a subarray of characters to the text stream.
        /// </summary>
        /// <param name="buffer">The character array to write data from.</param>
        /// <param name="index">Starting index in the buffer.</param>
        /// <param name="count">The number of characters to write.</param>
        /// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer"/> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char[] buffer, int index, int count)
        {
            this.decoratedTextWriter.Write(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of a decimal value to the text stream.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(decimal value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte floating-point value to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(double value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte floating-point value to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(float value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte signed integer to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(int value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte signed integer to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(long value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an object to the text stream by calling ToString on that object.
        /// </summary>
        /// <param name="value">The object to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(object value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">An object to write into the formatted string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        public override void Write(string format, object arg0)
        {
            this.decoratedTextWriter.Write(format, arg0);
        }

        /// <summary>
        /// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">An object to write into the formatted string.</param>
        /// <param name="arg1">An object to write into the formatted string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted", Justification = "Original comment from framework API.")]
        public override void Write(string format, object arg0, object arg1)
        {
            this.decoratedTextWriter.Write(format, arg0, arg1);
        }

        /// <summary>
        /// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">An object to write into the formatted string.</param>
        /// <param name="arg1">An object to write into the formatted string.</param>
        /// <param name="arg2">An object to write into the formatted string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted", Justification = "Original comment from framework API.")]
        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            this.decoratedTextWriter.Write(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg">The object array to write into the formatted string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> or <paramref name="arg"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to <paramref name="arg"/>. Length. </exception>
        public override void Write(string format, params object[] arg)
        {
            this.decoratedTextWriter.Write(format, arg);
        }

        /// <summary>
        /// Writes a string to the text stream.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(string value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte unsigned integer to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(uint value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte unsigned integer to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(ulong value)
        {
            this.decoratedTextWriter.Write(value);
        }

        /// <summary>
        /// Writes a line terminator to the text stream.
        /// </summary>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine()
        {
            this.decoratedTextWriter.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of a Boolean followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The Boolean to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(bool value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes a character followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes an array of characters followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="buffer">The character array from which data is read.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char[] buffer)
        {
            this.decoratedTextWriter.WriteLine(buffer);
        }

        /// <summary>
        /// Writes a subarray of characters followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="buffer">The character array from which data is read.</param>
        /// <param name="index">The index into <paramref name="buffer"/> at which to begin reading.</param>
        /// <param name="count">The maximum number of characters to write.</param>
        /// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="buffer"/> parameter is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(char[] buffer, int index, int count)
        {
            this.decoratedTextWriter.WriteLine(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of a decimal value followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The decimal value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(decimal value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of a 8-byte floating-point value followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte floating-point value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(double value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte floating-point value followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte floating-point value to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(float value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte signed integer followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte signed integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(int value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte signed integer followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte signed integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(long value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of an object by calling ToString on this object, followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The object to write. If <paramref name="value"/> is null, only the line termination characters are written.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(object value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatted string.</param>
        /// <param name="arg0">The object to write into the formatted string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        public override void WriteLine(string format, object arg0)
        {
            this.decoratedTextWriter.WriteLine(format, arg0);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">The object to write into the format string.</param>
        /// <param name="arg1">The object to write into the format string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted", Justification = "Original comment from framework API.")]
        public override void WriteLine(string format, object arg0, object arg1)
        {
            this.decoratedTextWriter.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">The object to write into the format string.</param>
        /// <param name="arg1">The object to write into the format string.</param>
        /// <param name="arg2">The object to write into the format string.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format"/> is null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted", Justification = "Original comment from framework API.")]
        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            this.decoratedTextWriter.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg">The object array to write into format string.</param>
        /// <exception cref="T:System.ArgumentNullException">A string or object is passed in as null. </exception>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to arg.Length. </exception>
        public override void WriteLine(string format, params object[] arg)
        {
            this.decoratedTextWriter.WriteLine(format, arg);
        }

        /// <summary>
        /// Writes a string followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The string to write. If <paramref name="value"/> is null, only the line termination characters are written.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(string value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of a 4-byte unsigned integer followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(uint value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of an 8-byte unsigned integer followed by a line terminator to the text stream.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer to write.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void WriteLine(ulong value)
        {
            this.decoratedTextWriter.WriteLine(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj)
        {
            return this.decoratedTextWriter.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.decoratedTextWriter.GetHashCode();
        }

        /// <summary>
        /// Creates an object that contains all the relevant information required to generate a proxy used to communicate with a remote object.
        /// </summary>
        /// <param name="requestedType">The <see cref="T:System.Type"/> of the object that the new <see cref="T:System.Runtime.Remoting.ObjRef"/> will reference.</param>
        /// <returns>
        /// Information required to generate a proxy.
        /// </returns>
        /// <exception cref="T:System.Runtime.Remoting.RemotingException">This instance is not a valid remoting object. </exception>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/>
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override System.Runtime.Remoting.ObjRef CreateObjRef(Type requestedType)
        {
            return this.decoratedTextWriter.CreateObjRef(requestedType);
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override object InitializeLifetimeService()
        {
            return this.decoratedTextWriter.InitializeLifetimeService();
        }
    }
}