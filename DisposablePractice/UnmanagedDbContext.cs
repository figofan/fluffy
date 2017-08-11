using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DisposablePractice
{
	public class UnmanagedDbContext : DbContext
	{
		private SqlCommand _command;
		private IntPtr _ptr;

		public override string GetDate()
		{
			if (_command == null)
				_command = new SqlCommand();

			if (_ptr == IntPtr.Zero)
				_ptr = Marshal.AllocHGlobal(1000 * 1024 * 1024);

			return base.GetDate();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_command?.Dispose();
			}

			if (_ptr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(_ptr);
				_ptr = IntPtr.Zero;
			}

			base.Dispose(disposing);
		}

		~UnmanagedDbContext()
		{
			Dispose(false);
		}
	}
}
