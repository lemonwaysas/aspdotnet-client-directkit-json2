using com.lemonway;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspdotnet_client_directkit_json2.Services
{
	/// <summary>
	/// Get user info from the http request
	/// </summary>
	public class EndUserInfoProvider : IEndUserInfoProvider
	{
		private readonly HttpRequest httpRequest;
		public EndUserInfoProvider(HttpRequest httpRequest)
		{
			this.httpRequest = httpRequest;
		}

		public EndUserInfo GetEndUserInfo()
		{
			return new EndUserInfo
			{
				IP = httpRequest.HttpContext.Connection.RemoteIpAddress.ToString(),
				UserAgent = httpRequest.Headers["User-Agent"].ToString()
			};
		}
	}
}
