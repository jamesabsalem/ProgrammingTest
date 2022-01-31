using System.Security.Cryptography;
using System.Text;

namespace ProgrammingTest.Web.Data
{
    public class RandomGenerator
    {
        private static readonly Random Random = new ();

        public static string RandomString(int length)
        {
            var lower = "abcdefghijklmnopqrstuvwxyz";
            var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var number = "1234567890";
            var alphanumeric = lower + upper + number;

            var randomString =new string(Enumerable.Repeat(alphanumeric, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
            var left = Random.Next(0, 9);
            var right = Random.Next(0, 9);
            var addedLeftSpace = new string(' ', left) + randomString;
            var addedRightSpace = addedLeftSpace + new string(' ', right);
            return addedRightSpace;
        }

        public static int RandomInteger()
        {
            using var rng = new RNGCryptoServiceProvider();
            var randomNumber = new byte[4];
            rng.GetBytes(randomNumber);
            var value = BitConverter.ToInt32(randomNumber, 0);
            return value;
        }
        public static float RandomFloat()
        {
            using var rng = new RNGCryptoServiceProvider();
            var randomNumber = new byte[4];
            rng.GetBytes(randomNumber);
            var value = BitConverter.ToSingle(randomNumber, 0);
            return value;
        }

    }
}
