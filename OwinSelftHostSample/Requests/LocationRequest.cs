namespace OwinSelftHostSample.Requests
{
	public class LocationRequest
	{
		/// <summary>
		///     Street address in local format
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		///     City name
		/// </summary>
		public string City { get; set; }

		/// <summary>
		///     State or province name or abbrevation
		/// </summary>
		public string State { get; set; }

		/// <summary>
		///     Zipcode or postal code
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		///     Country name or abbrevation
		/// </summary>
		public string Country { get; set; }
	}
}