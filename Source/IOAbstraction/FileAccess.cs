//-------------------------------------------------------------------------------
// <copyright file="FileAccess.cs" company="Daniel Marbach">
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Interfaces;
    using log4net;

    /// <summary>
    /// Wrapper class which simplifies the access to the file layer.
    /// </summary>
    public class FileAccess : IFileAccess
    {
        /// <summary>
        /// The logger of this class
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <inheritdoc />
        public void Delete(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Deleting file {0}", path);
            File.Delete(path);
        }

        /// <inheritdoc />
        public void Copy(string sourceFileName, string destFileName)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Copying file {0} to {1}.", sourceFileName, destFileName);

            File.Copy(sourceFileName, destFileName);
        }

        /// <inheritdoc />
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Copying file {0} to {1} with overwrite {2}.", sourceFileName, destFileName, overwrite ? "true" : "false");

            File.Copy(sourceFileName, destFileName, overwrite);
        }

        /// <inheritdoc />
        public IStreamWriterAccess CreateText(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Creating file {0}", path);
            return new StreamWriterAccess(File.CreateText(path));
        }

        /// <inheritdoc />
        public FileAttributes GetAttributes(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Getting attributes on file {0}.", path);
            return File.GetAttributes(path);
        }

        /// <inheritdoc />
        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Setting last write time of {0} to {1}", path, lastWriteTime);
            File.SetLastWriteTime(path, lastWriteTime);
        }

        /// <inheritdoc />
        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Setting attributes {0} on file {1}.", fileAttributes, path);
            File.SetAttributes(path, fileAttributes);
        }

        /// <inheritdoc />
        public bool Exists(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Checking if file {0} exists.", path);
            return File.Exists(path);
        }

        /// <inheritdoc />
        public IEnumerable<byte> ReadAllBytes(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading bytes of file {0}.", path);
            return File.ReadAllBytes(path);
        }

        /// <inheritdoc />
        public IEnumerable<string> ReadAllLines(string path, Encoding encoding)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all lines of file {0} with encoding {1}.", path, encoding);
            return File.ReadAllLines(path, encoding);
        }

        /// <inheritdoc />
        public IEnumerable<string> ReadAllLines(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all lines of file {0}.", path);
            return File.ReadAllLines(path);
        }

        /// <inheritdoc />
        public string ReadAllText(string path, Encoding encoding)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all text of file {0} with encoding {1}.", path, encoding);
            return File.ReadAllText(path, encoding);
        }

        /// <inheritdoc />
        public string ReadAllText(string path)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Reading all text of file {0}.", path);
            return File.ReadAllText(path);
        }

        /// <inheritdoc />
        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Writing all text {0} with encoding {1} to file {2}.", contents, encoding, path);
            File.WriteAllLines(path, contents.ToArray(), encoding);
        }

        /// <inheritdoc />
        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Writing all text {0} to file {1}.", contents, path);
            File.WriteAllLines(path, contents.ToArray());
        }

        /// <inheritdoc />
        public void WriteAllText(string path, string contents)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Writing all text {0} to file {1}.", contents, path);

            File.WriteAllText(path, contents);
        }

        /// <inheritdoc />
        public void WriteAllBytes(string path, byte[] bytes)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Writing all byte {0} to file {1}.", bytes, path);

            File.WriteAllBytes(path, bytes);
        }

        /// <inheritdoc />
        public Stream Open(string path, FileMode mode)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Opening file {0} with mode {1}.", path, mode);

            return File.Open(path, mode);
        }

        /// <inheritdoc />
        public Stream Open(string path, FileMode mode, System.IO.FileAccess access)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Opening file {0} with mode {1} and access {2}.", path, mode, access);

            return File.Open(path, mode, access);
        }

        /// <inheritdoc />
        public Stream Open(string path, FileMode mode, System.IO.FileAccess access, FileShare share)
        {
            Log.DebugFormat(CultureInfo.InvariantCulture, "Opening file {0} with mode {1}, access {2} and share {3}.", path, mode, access, share);

            return File.Open(path, mode, access, share);
        }
    }
}