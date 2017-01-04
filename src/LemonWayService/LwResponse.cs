using Newtonsoft.Json.Linq;

namespace com.lemonway
{
	/// <summary>
	/// All directkit json response is wrapped in the "d" object to prevent json-hijack issue
	/// </summary>
	public class LwResponse
	{
		public JObject d;

		/// <summary>
		/// If LW Service return a Business error, it will be stored in the "E" element
		/// </summary>
		public bool IsError()
		{
			return d["E"].HasValues;
		}
	}
}
