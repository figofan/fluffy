using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	public struct Maybe<T> : IEquatable<Maybe<T>> where T : class
	{
		private readonly T _value;
		public bool HasValue => _value != null;
		public T Value
		{
			get
			{
				if (!HasValue) throw new InvalidOperationException();
				return _value;
			}
		}

		private Maybe(T value)
		{
			_value = value;
		}

		public static implicit operator Maybe<T>(T value)
		{
			return new Maybe<T>(value);
		}

		public static bool operator ==(Maybe<T> maybe, T value)
		{
			return maybe.HasValue && maybe.Value.Equals(value);
		}

		public static bool operator !=(Maybe<T> maybe, T value)
		{
			return !(maybe == value);
		}

		public static bool operator ==(Maybe<T> first, Maybe<T> second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Maybe<T> first, Maybe<T> second)
		{
			return !(first == second);
		}

		public bool Equals(Maybe<T> other)
		{
			return EqualityComparer<T>.Default.Equals(_value, other._value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is Maybe<T> && Equals((Maybe<T>) obj);
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(_value);
		}

		public T Unwrap(T defaultValue = default(T))
		{
			return HasValue ? Value : defaultValue;
		}
	}
}
