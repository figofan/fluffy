using System;
using System.Collections.Generic;

namespace OwinSelftHostSample.Requests
{
	public class WorkOrderRequest
	{
		public WorkOrderRequest()
		{
			jobs = new List<JobRequest>();
		}

		/// <summary>
		/// Work order number
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// Date/time when customer placed the order. It should be in UTC form.
		/// </summary>
		public DateTime orderedOn { get; set; }

		/// <summary>
		/// Identifier of source of information. It will be used to filter standard master tables.
		/// </summary>
		public string source { get; set; }

		/// <summary>
		/// List of jobs associated to this work order
		/// </summary>
		public IList<JobRequest> jobs { get; set; }
	}
}