using System.Runtime.Serialization;

namespace Common.CusomterExeptions
{
	public class UserValidatorExeption : Exception
	{
		public UserValidatorExeption()
		{
		}
       
        public UserValidatorExeption(string message) : base(message)
		{
		}

		public UserValidatorExeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected UserValidatorExeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
