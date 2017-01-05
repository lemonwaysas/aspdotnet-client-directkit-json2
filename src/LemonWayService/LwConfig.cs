namespace com.lemonway
{
	/// <summary>
	/// BackOffice credentials is required for each LwRequest
	/// </summary>
	public class LwConfig
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string Language { get; set; } = "en";
		public string Version { get; set; } = "10.0";

		public override string ToString()
		{
			return $"({nameof(LwConfig)}: {nameof(Login)}={Login}, {nameof(Password)}={Password}, {nameof(Version)}={Version})";
		}
	}
}