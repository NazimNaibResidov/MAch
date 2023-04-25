using System.Security.Cryptography;
using System.Text;

namespace Common.Core.Encryptions
{
	public class PasswordEncryption
	{
		public static string Encryption(string password)
		{
			using var md5 = MD5.Create();
			byte[] inputByte = Encoding.ASCII.GetBytes(password);
			byte[] hashByte = md5.ComputeHash(inputByte);
			return Convert.ToHexString(hashByte);
		}
	}
}
