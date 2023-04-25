using System.Runtime.Serialization;

namespace Common.CusomterExeptions
{
	public class PasswordValidatorExeption : Exception
	{
		public PasswordValidatorExeption()
		{
		}

		public PasswordValidatorExeption(string message) : base(message)
		{
		}

		public PasswordValidatorExeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected PasswordValidatorExeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
