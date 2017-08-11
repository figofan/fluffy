using System;

namespace OwinSelftHostSample.Requests
{
	public class JobRequest
	{
		public JobRequest()
		{
			BillingInfo = new BillingInfoRequest();
			CustomerInfo = new CustomerInfoRequest();
			Location = new LocationRequest();
		}

		/// <summary>
		/// Unique identifier of job within a work order
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// Unique identifier for the job assigned to this technician for this date
		/// </summary>
		public string ShortCode { get; set; }

		/// <summary>
		/// Billing system estimate of job duration
		/// </summary>
		public int? Points { get; set; }

		/// <summary>
		/// Start time of a window when job is scheduled to start. It should be in UTC form.
		/// </summary>
		public DateTime CommitedArrivalFrom { get; set; }

		/// <summary>
		/// Endttime of a window when job is scheduled to start. It should be in UTC form.
		/// </summary>
		public DateTime CommitedArrivalTo { get; set; }

		/// <summary>
		/// Container for billing system related information
		/// </summary>
		public BillingInfoRequest BillingInfo { get; set; }

		/// <summary>
		/// Container for customer related information
		/// </summary>
		public CustomerInfoRequest CustomerInfo { get; set; }

		/// <summary>
		/// Container for location related information
		/// </summary>
		public LocationRequest Location { get; set; }
	}
}
