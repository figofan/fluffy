namespace OwinSelftHostSample.Requests
{
	public class BillingInfoRequest
	{
		/// <summary>
		///     Total Balance Due on this account
		/// </summary>
		public decimal TotalBalanceDue { get; set; }

		/// <summary>
		///     Recurring monthly charge on this account
		/// </summary>
		public decimal MonthlyCharge { get; set; }

		/// <summary>
		///     Amount to be collected from the customer by the FSR upon performing the service
		/// </summary>
		public decimal CodAmount { get; set; }

		/// <summary>
		///     Summary of monthly and one-time charge
		/// </summary>
		public decimal TotalCharge { get; set; }

		/// <summary>
		///     Summary of new and existing one-time charges
		/// </summary>
		public decimal OneTimeCharge { get; set; }
	}
}