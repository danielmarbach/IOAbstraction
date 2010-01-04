//-------------------------------------------------------------------------------
// <copyright file="TextReaderAccess.cs" company="Daniel Marbach">
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
    using System.Security.Permissions;
    using Interfaces;

    /// <summary>
    /// <see cref="TextReader"/> decorator.
    /// </summary>
    public abstract class TextReaderAccess : TextReader, ITextReaderAccess
    {
        /// <summary>
        /// Holds the decorated <see cref="TextReader"/>.
        /// </summary>
        private readonly TextReader decoratedTextReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextReaderAccess"/> class.
        /// </summary>
        /// <param name="textReader">The text reader.</param>
        protected TextReaderAccess(TextReader textReader)
        {
            this.decoratedTextReader = textReader;
        }

        /// <summary>
        /// Closes the <see cref="T:System.IO.TextReader"/> and releases any system resources associated with the TextReader.
        /// </summary>
        public override void Close()
        {
            this.decoratedTextReader.Close();
        }

        /// <summary>
        /// Reads the next character without changing the state of the reader or the character source. Returns the next available character without actually reading it from the input stream.
        /// </summary>
        /// <returns>
        /// An integer representing the next character to be read, or -1 if no more characters are available or the stream does not support seeking.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        public override int Peek()
        {
            return this.decoratedTextReader.Peek();
        }

        /// <summary>
        /// Reads the next character from the input stream and advances the character position by one character.
        /// </summary>
        /// <returns>
        /// The next character from the input stream, or -1 if no more characters are available. The default implementation returns -1.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        public override int Read()
        {
            return this.decoratedTextReader.Read();
        }

        /// <summary>
        /// Reads a maximum of <paramref name="count"/> characters from the current stream and writes the data to <paramref name="buffer"/>, beginning at <paramref name="index"/>.
        /// </summary>
        /// <param name="buffer">When this method returns, contains the specified character array with the values between <paramref name="index"/> and (<paramref name="index"/> + <paramref name="count"/> - 1) replaced by the characters read from the current source.</param>
        /// <param name="index">The place in <paramref name="buffer"/> at which to begin writing.</param>
        /// <param name="count">The maximum number of characters to read. If the end of the stream is reached before <paramref name="count"/> of characters is read into <paramref name="buffer"/>, the current method returns.</param>
        /// <returns>
        /// The number of characters that have been read. The number will be less than or equal to <paramref name="count"/>, depending on whether the data is available within the stream. This method returns zero if called when no more characters are left to read.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="buffer"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        public override int Read(char[] buffer, int index, int count)
        {
            return this.decoratedTextReader.Read(buffer, index, count);
        }

        /// <summary>
        /// Reads a maximum of <paramref name="count"/> characters from the current stream, and writes the data to <paramref name="buffer"/>, beginning at <paramref name="index"/>.
        /// </summary>
        /// <param name="buffer">When this method returns, this parameter contains the specified character array with the values between <paramref name="index"/> and (<paramref name="index"/> + <paramref name="count"/> -1) replaced by the characters read from the current source.</param>
        /// <param name="index">The place in <paramref name="buffer"/> at which to begin writing.</param>
        /// <param name="count">The maximum number of characters to read.</param>
        /// <returns>
        /// The position of the underlying stream is advanced by the number of characters that were read into <paramref name="buffer"/>.
        /// The number of characters that have been read. The number will be less than or equal to <paramref name="count"/>, depending on whether all input characters have been read.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="buffer"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> or <paramref name="count"/> is negative.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            return this.decoratedTextReader.ReadBlock(buffer, index, count);
        }

        /// <summary>
        /// Reads a line of characters from the current stream and returns the data as a string.
        /// </summary>
        /// <returns>
        /// The next line from the input stream, or null if all characters have been read.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        /// <exception cref="T:System.OutOfMemoryException">
        /// There is insufficient memory to allocate a buffer for the returned string.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The number of characters in the next line is larger than <see cref="F:System.Int32.MaxValue"/></exception>
        public override string ReadLine()
        {
            return this.decoratedTextReader.ReadLine();
        }

        /// <summary>
        /// Reads all characters from the current position to the end of the TextReader and returns them as one string.
        /// </summary>
        /// <returns>
        /// A string containing all characters from the current position to the end of the TextReader.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">
        /// An I/O error occurs.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// The <see cref="T:System.IO.TextReader"/> is closed.
        /// </exception>
        /// <exception cref="T:System.OutOfMemoryException">
        /// There is insufficient memory to allocate a buffer for the returned string.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The number of characters in the next line is larger than <see cref="F:System.Int32.MaxValue"/></exception>
        public override string ReadToEnd()
        {
            return this.decoratedTextReader.ReadToEnd();
        }

        /// <summary>
        /// Creates an object that contains all the relevant information required to generate a proxy used to communicate with a remote object.
        /// </summary>
        /// <param name="requestedType">The <see cref="T:System.Type"/> of the object that the new <see cref="T:System.Runtime.Remoting.ObjRef"/> will reference.</param>
        /// <returns>
        /// Information required to generate a proxy.
        /// </returns>
        /// <exception cref="T:System.Runtime.Remoting.RemotingException">
        /// This instance is not a valid remoting object.
        /// </exception>
        /// <exception cref="T:System.Security.SecurityException">
        /// The immediate caller does not have infrastructure permission.
        /// </exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/>
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
        {
            return this.decoratedTextReader.CreateObjRef(requestedType);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            return this.decoratedTextReader.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.decoratedTextReader.GetHashCode();
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">
        /// The immediate caller does not have infrastructure permission.
        /// </exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override object InitializeLifetimeService()
        {
            return this.decoratedTextReader.InitializeLifetimeService();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.decoratedTextReader.ToString();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.IO.TextReader"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.decoratedTextReader.Dispose();
        }
    }
}