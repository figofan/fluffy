using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Arris.Common.Clients;

namespace DesignPattern
{
	[TestClass]
	public class HttpClientTest
	{
		[TestMethod]
		public async Task TestHttpClient()
		{

			var workOrder = await PostWorkOrder();
			Assert.IsNotNull(workOrder);
		}


		[TestMethod]
		public  void  TestWithRestClient()
		{
			var workOrderReturned = new WorkOrdersService().PostWorkOrder();
			Assert.IsNotNull(workOrderReturned);
		}

		[TestMethod]
		public void TestWithArrisRestPackage()
		{
			var workOrderReturned = new WorkOrdersService().PostWorkOrder();
			Assert.IsNotNull(workOrderReturned);
		}


	    [TestMethod]
	    public async Task TestConfig()
	    {
	        var httpClient = new HttpClient();
	        httpClient.BaseAddress = new Uri("https://configurationslocal.workassureonlinedev.com/1/0/Configurations");

            var uri = new Uri("7FA61AD4-F9A5-4EF9-A4DE-1BD0AA52F30F", UriKind.Relative);
	        var result =
	            await httpClient.GetAsync(uri);
            
            Assert.IsNotNull(result);

	    }

        [TestMethod]
        public async Task TestConfigRelativePath()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://configurationslocal.workassureonlinedev.com/1/0/Configurations");

            //var uri = new Uri("7FA61AD4-F9A5-4EF9-A4DE-1BD0AA52F30F", UriKind.Relative);
            var request = new HttpRequestMessage(HttpMethod.Get, "7FA61AD4-F9A5-4EF9-A4DE-1BD0AA52F30F");
            //var result =
            //    await httpClient.GetAsync(uri);
            var result = await httpClient.SendAsync(request);

            var path = new Uri(new Uri("https://configurationslocal.workassureonlinedev.com/a/1/0/Configurations"), "/1/0/7FA61AD4-F9A5-4EF9-A4DE-1BD0AA52F30F");
            Assert.IsNotNull(result);

        }
        public async Task<string> PostWorkOrder()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://127.0.0.1:8989/PostWorkOrderStub/1/0/Workorders");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var workOrderRequest = new WorkOrderRequest()
			{
				Code = "Code008",
				Source = "ICOMS"
			};

			var content = new StringContent(
					JsonConvert.SerializeObject(workOrderRequest),
					Encoding.UTF8,
					"application/json");
			var response = await client.PostAsync("", content);
			if (response.IsSuccessStatusCode)
				return await response.Content.ReadAsStringAsync();
			return string.Empty;
		} 
	}

	class WorkOrderRequest
	{
		public string Code { get; set; }
		public string Source { get; set; }
	}

	public class WorkOrdersService : BaseService
	{
		public WorkOrdersService()
		{
			Settings.BaseUri = "http://127.0.0.1:8989/PostWorkOrderStub/1/0/Workorders";
		}

		public string PostWorkOrder()
		{
			var workOrderRequest = new WorkOrderRequest()
			{
				Code = "Code008999900909i",
				Source = "ICOMS"
			};
			return Post<string>(workOrderRequest, string.Empty);
		}
	}
	public class BaseService : Client
	{

		public BaseService()
			: base(new ClientSettings()
			{
				RetryAttempts = 2,
				RetryIntervalInMilliseconds = 500,
				TimeoutInMilliseconds = 300000
			})
		{

		}

		protected IEnumerable<KeyValuePair<string, string>> GetDefaultHeaders()
		{
			return new Dictionary<string, string> {{"Authorization", "facke jwt"}};
		}

		protected T Get<T>(string uri, params object[] uriParameters)
		{
			return GetResult<T>(GetAsync<T>(GetDefaultHeaders(), uri, uriParameters));
		}

		protected T Post<T>(object content, string uri, params object[] uriParameters)
		{
			//

			return GetResult<T>(PostAsync(content, GetDefaultHeaders(), uri, uriParameters));
		}

		//protected new async Task<ClientResponse> PostAsync(object content, IEnumerable<KeyValuePair<string, string>> headers, string uri, params object[] uriParameters)
		//{
		//	return await SendAsync(content, HttpMethod.Post, headers, uri, uriParameters).ConfigureAwait(false);
		//}

		private async Task<ClientResponse> SendAsync(object content, HttpMethod httpMethod, IEnumerable<KeyValuePair<string, string>> headers, string uri, object[] parameters)
		{
			var request = BuildRestClientRequest(content, httpMethod, headers, uri, parameters);

			return await SendAsync(request).ConfigureAwait(false);
		}

		private HttpClient BuildClient(string uriString, int timeout)
		{
			var uri = new Uri(uriString);

			var client = new System.Net.Http.HttpClient
			{
				BaseAddress = uri,
				Timeout = new TimeSpan(0, 0, 0, 0, timeout)
			};

			//set the connection timeout here to avoid DNS issues (see http://byterot.blogspot.com/2016/07/singleton-httpclient-dns.html)
			var sp = ServicePointManager.FindServicePoint(uri);
			sp.ConnectionLeaseTimeout = Convert.ToInt32(10000);

			return client;
		}

		//protected new async Task<ClientResponse> SendAsync(ClientRequest request)
		//{
		//	using (var httpResponse = await SendGenericAsync(request).ConfigureAwait(false))
		//	{
		//		string contentResult = null;

		//		if (httpResponse.Content != null)
		//		{
		//			contentResult = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
		//		}

		//		return new ClientResponse(httpResponse, contentResult);
		//	}
		//}

		private async Task<HttpResponseMessage> SendGenericAsync(ClientRequest apiClientRequest)
		{
			HttpResponseMessage response = null;

			for (int retry = 0; retry <= Settings.RetryAttempts; retry++)
			{

				response = null;

				try
				{
					var client = BuildClient(Settings.BaseUri, Settings.TimeoutInMilliseconds);

					try
					{
						var request = BuildRequest(apiClientRequest);

						response = await client.SendAsync(request).ConfigureAwait(false);

						if (ShouldRetry(response) == false)
						{
							return response;
						}
					}
					catch (Exception ex)
					{
						if (ShouldRetry(ex) == false)
						{
							throw;
						}
					}

					await Task.Delay(Settings.RetryIntervalInMilliseconds).ConfigureAwait(false);
				}
				finally
				{
					
				}
			}

			return response;
		}

		private HttpRequestMessage BuildRequest(ClientRequest restClientRequest)
		{
			var message = new HttpRequestMessage(
				restClientRequest.HttpMethod,
				BuildOperationUri(restClientRequest.Uri,
				restClientRequest.UriParameters.ToArray()));


			foreach (var a in restClientRequest.Headers)
			{
				message.Headers.Add(a.Key, a.Value);
			}

			if (restClientRequest.Content != null)
				message.Content = new StringContent(
					JsonConvert.SerializeObject(restClientRequest.Content
					, new JsonSerializerSettings()
					{
						DateTimeZoneHandling = DateTimeZoneHandling.Utc,
						ContractResolver = new CamelCasePropertyNamesContractResolver(),
						NullValueHandling = NullValueHandling.Ignore,
						Converters = { new StringEnumConverter() }
					}
					),
					Encoding.UTF8,
					"application/json");

			return message;
		}

		private ClientRequest BuildRestClientRequest(object content, HttpMethod httpMethod, IEnumerable<KeyValuePair<string, string>> headers, string uri, object[] parameters)
		{
			var request = new ClientRequest()
			{
				Content = content,
				HttpMethod = httpMethod,
				Uri = uri
			};
			request.UriParameters.AddRange(parameters);

			//add custom headers

			foreach (var header in headers)
			{
				request.Headers[header.Key] = header.Value;
			}

			return request;
		}

		private string BuildOperationUri(string url, params object[] parameters)
		{
			if (parameters.Any())
			{
				var encodedParameters = parameters.Select(a => (object)HttpUtility.UrlEncode(a.ToString())).ToArray();

				return string.Format(url, encodedParameters);
			}
			else
			{
				return url;
			}
		}

		protected T GetResult<T>(Task<ClientResponse> task)
		{
			var response = task.ConfigureAwait(false).GetAwaiter().GetResult();
			return response.WasSuccessful ? response.Result<T>() : default(T);
		}
	}
}
