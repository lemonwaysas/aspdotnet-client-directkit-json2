using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.lemonway
{
	public class LemonWayException: Exception
	{
		public LemonWayException(string message): base(message)
		{

		}	
	}

	/// <summary>
	/// Technical error Network, Connection when connect to the Service
	/// </summary>
	public class ServiceException : LemonWayException
	{
		public ServiceException(string message) : base(message)
		{

		}
	}

	/// <summary>
	/// Receive a reponse for Lemonway but it is a business erreur. ("Wallet not exist", "Amount is too high"..)
	/// </summary>
	public class BusinessException : LemonWayException
	{
		public string ErrorCode { get; private set; }
		public string ErrorMessage { get; private set; }

		/// <summary>
		/// Do not display it to your end-user
		/// </summary>
		public string PrivateInfo { get; private set; }

		public BusinessException(string errorCode, string message, string privateInfo) : base($"{errorCode} - {message}")
		{
			this.ErrorCode = errorCode;
			this.ErrorMessage = message;
			this.PrivateInfo = privateInfo;
		}

		public override string ToString()
		{
			return $"(BusinessException: {ErrorCode} - {ErrorMessage}; {PrivateInfo})";
		}
	}
}