using System;

namespace Learn_Password
{
	public class Encryption
	{
		public static string Encrypt( string input)
		{
			if( input == null)
			{
				throw new System.NullReferenceException( "Passed a null reference");
			}
			System.Random rnd = new System.Random();
			byte ri = (byte)rnd.Next( 0,256);
			string s = ri.ToString( "X2");
			char[] inputC = input.ToCharArray();
			for( int i=0;i< inputC.Length;i++)
			{
				s += (((byte)~inputC[i])^ri).ToString( "X2");
			}
			return s;
		}

		public static string Decrypt( string input)
		{
			string ret = null;
			if( input == null)
			{
				throw new System.NullReferenceException( "Passed a null reference");
			}
			if( input.Length > 0 && input.Length % 2 == 0)
			{
				string ris = input.Substring( 0,2);
				byte ri = byte.Parse( ris, System.Globalization.NumberStyles.HexNumber);
				ret = "";
				for( int i=2;i<input.Length;i+=2)
				{
					byte ascii = byte.Parse(input.Substring( i,2), System.Globalization.NumberStyles.HexNumber);
					ret+=((char)(((byte)~ascii)^ri)).ToString();
				}
			}
			else
			{
				throw new System.Exception( "The passed in string to decrypt is an incorrect length or empty");
			}
			return ret;
		}
	}
}
