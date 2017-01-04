namespace com.lemonway
{
	/// <summary>
	/// Provide the EndUserInfo (IP + UserAgent)
	/// In your Aspx Application, you should implement this interface so that it return the IP and User agent of your end user
	/// </summary>
	public interface IEndUserInfoProvider
	{
		EndUserInfo GetEndUserInfo();
	}
}