using System;

namespace com.lemonway
{
	/// <summary>
	/// Persiste the configuration through request creation
	/// </summary>
    public class LwRequestFactory
    {
		private LwConfig config;
		private IEndUserInfoProvider euip;

		public LwRequestFactory(LwConfig config = null, IEndUserInfoProvider euip = null)
		{
			this.config = config;
			this.euip = euip;
		}

		public LwRequestFactory(LwConfig config, EndUserInfo eui) : 
			this(config, new DummyEndUserInfoProvider(eui)) { }

		public LwRequest CreateRequest()
		{
			if (config == null)
				throw new InvalidOperationException("You must to call SetConfig() before");
			if (euip == null)
				throw new InvalidOperationException("You must to call SetEndUserInfo() or SetEndUserInfoProvider() before");
			return new LwRequest(config, euip);
		}

		#region Shortcut

		public void SetConfig(LwConfig config)
		{
			this.config = config;
		}
		public void SetEndUserInfo(EndUserInfo endUserInfo)
		{
			this.euip = new DummyEndUserInfoProvider(endUserInfo);
		}
		public void SetEndUserInfoProvider(IEndUserInfoProvider endUserInfoProvider)
		{
			this.euip = endUserInfoProvider;
		}

		#endregion

		/// <summary>
		/// Convert an EndUserInfo to a IEndUserInfoProvider
		/// </summary>
		private class DummyEndUserInfoProvider : IEndUserInfoProvider
		{
			private EndUserInfo eui;
			public DummyEndUserInfoProvider(EndUserInfo eui)
			{
				this.eui = eui;
			}
			public EndUserInfo GetEndUserInfo()
			{
				return eui;
			}
		}
	}
}
