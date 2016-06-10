using System.Net.Http;
using System.Threading.Tasks;
using PhotoEditor.Core.Utilities;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace PhotoEditor.Core.Services.Implementation
{
	public class RestServiceClient : IRestServiceClient
	{
		private async Task ExecuteRequest(IRestRequest request)
		{
			var requestTask = Task.Run(async () =>
			{
				var client = new RestClient(ServiceUris.BaseUri) { IgnoreResponseStatusCode = true };
				var response = await client.Execute(request);
				if (response.IsSuccess == false)
					throw new HttpRequestException(response.StatusCode.ToString());
			});
			await requestTask;
		}

		private async Task<TResult> ExecuteRequest<TResult>(IRestRequest request)
		{
			var requestTask = Task.Run(async () =>
			{
				var client = new RestClient(ServiceUris.BaseUri) { IgnoreResponseStatusCode = true };
				var response = await client.Execute<TResult>(request);
				if (response.IsSuccess == false)
					throw new HttpRequestException(response.StatusCode.ToString());

				return response.Data;
			});
			return await requestTask;
		}
	}
}