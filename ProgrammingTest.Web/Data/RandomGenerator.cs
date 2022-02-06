using System.Text;

namespace ProgrammingTest.Web.Data
{
    public class RandomGenerator
    {
        public static string RandomString(int length)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "1234567890";
            const string alphanumeric = lower + upper + number;
            Random random = new();
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var character = alphanumeric[random.Next(0, alphanumeric.Length)];
                stringBuilder.Append(character);
            }
            var (left, right) = RandomSpace();
            var addedLeftSpace = new string(' ', left) + stringBuilder;
            var addedRightSpace = addedLeftSpace + new string(' ', right);
            return addedRightSpace;
        }

        private static (int left, int right) RandomSpace()
        {
            Random random = new();
            var left = 0;
            var right = 0;
            var l = random.Next(0, 9);
            var r = random.Next(0, 9);
            if (l + r > 10) return (left, right);
            left = l;
            right = r;
            return (left, right);
        }

        public static int RandomInteger()
        {
            var r = new Random();
            var n = r.Next();
            return n;
        }
        public static float RandomFloat()
        {
            var random = new Random();
            const double range = float.MaxValue - (double)float.MinValue;
            var sample = random.NextDouble();
            var scaled = (sample * range) + float.MinValue;
            var f = (float)scaled;
            return f;
        }
    }
}
