using System;
using Xunit;

namespace com.lemonway
{
	public class LwRequestTests
	{
		LwConfig config = new LwConfig
		{
			Login = "society",
			Password = "123456",
			Language = "en",
			Version = "4.0"
		};

		EndUserInfo client = new EndUserInfo
		{
			IP = "127.0.0.1",
			UserAgent = "xunit"
		};

		[Fact]
		public void Create_request()
		{
			var request = new LwRequest(config, client);
			Assert.Equal("society", request.p["wlLogin"]);
			Assert.Equal("123456", request.p["wlPass"]);
			Assert.Equal("en", request.p["language"]);
			Assert.Equal("4.0", request.p["version"]);
			Assert.Equal("127.0.0.1", request.p["walletIp"]);
			Assert.Equal("xunit", request.p["walletUa"]);


			request.Set("foo", "bar");
			Assert.Equal("bar", request.p["foo"]);
		}

		[Fact]
		public void Create_request_with_factory() 
		{
			//prepare the request factory
			var factory = new LwRequestFactory(config, client);

			//prepare the request
			var request = factory.CreateRequest(); //equivalent to: var request = new LwRequest(config, client);
			Assert.Equal("society", request.p["wlLogin"]);
			Assert.Equal("123456", request.p["wlPass"]);
			Assert.Equal("en", request.p["language"]);
			Assert.Equal("4.0", request.p["version"]);
			Assert.Equal("127.0.0.1", request.p["walletIp"]);
			Assert.Equal("xunit", request.p["walletUa"]);


			request.Set("foo", "bar");
			Assert.Equal("bar", request.p["foo"]);
		}


		[Fact]
		public void Create_request_with_endUserProvider()
		{
			//TODO Moq
		}
	}
}
