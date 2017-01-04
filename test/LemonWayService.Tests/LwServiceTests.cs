using System.Diagnostics;
using Xunit;

namespace com.lemonway
{
	public class LwServiceTests
	{
		/// <summary>
		/// Before running the test. Please replace it with YOUR directkit URL. 
		/// 1) Your directkit URL is sent to you by our Operation team.
		/// 2) You also have to ask the Operation team to whitelist your machine's IP address first. Otherwise, you cannot call any service.
		/// </summary>
		public static readonly string DIRECTKIT_JSON2 = "https://sandbox-api.lemonway.fr/mb/demo/dev/directkitjson2/Service.asmx";
		LwService service = new LwService(DIRECTKIT_JSON2);
		LwRequestFactory factory = new LwRequestFactory(new LwConfig
		{
			Login = "society",
			Password = "123456",
			Language = "en",
			Version = "4.0"
		});

		public LwServiceTests()
		{
			//in production, you must to set the IP of your end-user here.
			//you should implement an IEndUserInfoProvider if needed
			factory.SetEndUserInfo(new EndUserInfo
			{
				IP = "127.0.0.1",
				UserAgent = "xunit"
			});
		}

		/// <summary>
		/// read the LemonWay's documentation to know what to put in the request
		/// http://documentation.lemonway.fr/api-en/directkit/manage-wallets/getwalletdetails-getting-detailed-wallet-data
		/// </summary>
		[Fact]
		public void GetWalletDetails_test()
		{
			var request = factory.CreateRequest();
			var response = service.Call("GetWalletDetails", request.Set("wallet", "sc"));
			Assert.Equal("sc", response.d["WALLET"]["ID"].ToString());
			Debug.WriteLine(response.ToString());
		}
	}
}
