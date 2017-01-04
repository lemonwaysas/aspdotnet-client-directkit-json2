using Newtonsoft.Json.Linq;

namespace com.lemonway
{
	/// <summary>
	/// All directkit json request is wrapped in the "p" object to prevent json-hijack issue.
	/// All the request must to contains basic information:
	/// - login / password backoffice that call the request
	/// - the version (use a high value to ensure to query the lastest API version)
	/// - IP and UserAgent of your end-user (not your server)
	/// </summary>
	public class LwRequest
	{
		public JObject p;

		/// <summary>
		/// Create a LwRequest and fill some required parameters
		/// </summary>
		/// <param name="config"></param>
		/// <param name="endUserInfo"></param>
		public LwRequest(LwConfig config, EndUserInfo endUserInfo)
		{
			p = new JObject();
			Set("wlLogin", config.Login);
			Set("wlPass", config.Password);
			Set("language", config.Language);
			Set("version", config.Version);
			Set("walletIp", endUserInfo.IP);
			Set("walletUa", endUserInfo.UserAgent);
		}

		public LwRequest(LwConfig config, IEndUserInfoProvider endUserInfoProvider): this(config, endUserInfoProvider.GetEndUserInfo())
		{
		}

		/// <summary>
		/// short-hand to set request parameter to the "p" wrapper
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public LwRequest Set(string key, string value)
		{
			p[key] = value;
			return this;
		}
		/// <summary>
		/// short-hand to set request parameter to the "p" wrapper
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public LwRequest Set(string key, double value)
		{
			Set(key, value.ToString("0.00"));
			return this;
		}
	}
}
