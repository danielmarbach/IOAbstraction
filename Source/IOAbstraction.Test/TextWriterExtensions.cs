//-------------------------------------------------------------------------------
// <copyright file="TextWriterExtensions.cs" company="Daniel Marbach">
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
    using System;

    /// <summary>
    /// Extension methods for <see cref="TextWriterAccess"/> base classes.
    /// </summary>
    internal static class TextWriterExtensions
    {
        /// <summary>
        /// Calls the action on the value and auto flushes
        /// </summary>
        /// <typeparam name="TTestee">The type of the testee.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="action">The action to be executed.</param>
        public static void AutoFlush<TTestee>(this TTestee value, Action<TTestee> action)
            where TTestee : TextWriterAccess
        {
            action(value);
            value.Flush();
        }
    }
}