using System;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.lemonway
{
	/// <summary>
	/// Helper to call LemonwayService
	/// </summary>
	public class LwService
	{
		private string directkitUrl;
		private bool throwBusinessException;

		public LwService(string directkit_json2_url, bool throwBusinessException = true)
		{
			this.directkitUrl = directkit_json2_url;
			this.throwBusinessException = throwBusinessException;
		}

		public async Task<LwResponse> CallAsync(string serviceName, LwRequest request) 
		{
			var serviceUrl = $"{directkitUrl}/{serviceName}";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(serviceUrl);

				//client.DefaultRequestHeaders.Accept.Clear();
				var jsonContent = JsonConvert.SerializeObject(request);
				var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(serviceUrl, postContent);
				if (response.IsSuccessStatusCode)
				{
					var responseJson = await response.Content.ReadAsStringAsync();
					var resu = JsonConvert.DeserializeObject<LwResponse>(responseJson);

					if (throwBusinessException)
					{
						//check if the service returned a Business error
						var err = resu.d["E"];
						if (err.HasValues)
						{
							throw new BusinessException(err["Code"].ToString(), err["Msg"].ToString(), err["Error"].ToString());
						}
					}

					return resu;
				}
				throw new ServiceException($"Failed to call service {serviceName}: {response.StatusCode} - {response.Content}");
			}
		}

		public LwResponse Call(string serviceName, LwRequest request) 
		{
			var t = CallAsync(serviceName, request);
			try
			{
				t.Wait();
			}
			catch (AggregateException ex)
			{
				throw ex.Flatten().InnerException;
			}
			return t.Result;
		}
	}
}
