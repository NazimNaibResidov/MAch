using System.Runtime.Serialization;

namespace Common.CusomterExeptions
{
	public class DataBaseValidatorExeption : Exception
	{
		public DataBaseValidatorExeption()
		{
		}

		public DataBaseValidatorExeption(string message) : base(message)
		{
		}

		public DataBaseValidatorExeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected DataBaseValidatorExeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
