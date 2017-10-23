using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	public class Result
	{
		public bool IsSuccess { get; }
		public ErrorType? ErrorType { get; }

		protected Result(bool isSuccess, ErrorType? errorType)
		{
			IsSuccess = isSuccess;
			ErrorType = errorType;
		}

		public static Result<T> Ok<T>(T value)
		{
			return new Result<T>(value, true, null);
		}

		public static Result Fail(ErrorType errorType)
		{
			return new Result(false, errorType);
		}

		public static Result<T> Fail<T>(ErrorType errorType)
		{
			return new Result<T>(default(T), false, errorType);
		}
	}

	public enum ErrorType
	{
		DatabaseOffline,
		UserAlreadyExists
	}

	public class Result<T> : Result
	{
		private readonly T _value;

		public T Value
		{
			get
			{
				if (!IsSuccess) throw new InvalidOperationException();
				return _value;
			}
		}

		public Result(T value, bool isSuccess, ErrorType? errorType) : base(isSuccess, errorType)
		{
			_value = value;
		}
	}


	public class ResultPractice
	{
		public Result<Customer> GetCustomer()
		{
			try
			{
				return Result.Ok(new Customer());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return Result.Fail<Customer>(ErrorType.UserAlreadyExists);
			}
		}

		public class Customer
		{
			
		}
	}
}
