﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace dnSpy.Decompiler.Shared {
	public struct TextPosition : IEquatable<TextPosition>, IComparable<TextPosition> {
		/// <summary>
		/// Line, 0-based
		/// </summary>
		public int Line { get; }

		/// <summary>
		/// Column, 0-based
		/// </summary>
		public int Column { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="line">Line, 0-based</param>
		/// <param name="column">Column, 0-based</param>
		public TextPosition(int line, int column) {
			if (line < 0)
				throw new ArgumentOutOfRangeException(nameof(line));
			if (column < 0)
				throw new ArgumentOutOfRangeException(nameof(column));
			this.Line = line;
			this.Column = column;
		}

		public static bool operator <(TextPosition a, TextPosition b) => a.CompareTo(b) < 0;
		public static bool operator <=(TextPosition a, TextPosition b) => a.CompareTo(b) <= 0;
		public static bool operator >(TextPosition a, TextPosition b) => a.CompareTo(b) > 0;
		public static bool operator >=(TextPosition a, TextPosition b) => a.CompareTo(b) >= 0;
		public static bool operator ==(TextPosition a, TextPosition b) => a.Equals(b);
		public static bool operator !=(TextPosition a, TextPosition b) => !a.Equals(b);

		public int CompareTo(TextPosition other) {
			int c = Line.CompareTo(other.Line);
			if (c != 0)
				return c;
			return Column.CompareTo(other.Column);
		}

		public bool Equals(TextPosition other) => Line == other.Line && Column == other.Column;

		public override bool Equals(object obj) {
			var other = obj as TextPosition?;
			return other != null && Equals(other.Value);
		}

		public override int GetHashCode() => (Line << 10) ^ Column;
		public override string ToString() => $"({Line + 1},{Column + 1})";
	}
}
