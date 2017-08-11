using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using OwinSelftHostSample.Requests;

namespace OwinSelftHostSample
{
	[RoutePrefix("v2/Ingest/Workorders")]
	public class WorkOrdersController : ApiController
	{
		public static WorkOrderRequest PostedWorkOrderRequest;

		[Route]
		[HttpPut]
		//[Route("1/0/workorder")]
		public Guid PostWorkOrder([FromBody] WorkOrderRequest request)
		{
			PostedWorkOrderRequest = request;
			var workOrderId = Guid.NewGuid();
			Console.WriteLine($"PostWorkOrder is called, returned with id {workOrderId}");

			return workOrderId;
		}
	}
}
