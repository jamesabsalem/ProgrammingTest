namespace ProgrammingTest.Web.Data
{
    public class RandomGenerator
    {

        public static string RandomString(int length)
        {
            Random random = new();
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "1234567890";
            const string alphanumeric = lower + upper + number;
            var randomString =new string(Enumerable.Repeat(alphanumeric, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var left = random.Next(0, 9);
            var right = random.Next(0, 9);
            var addedLeftSpace = new string(' ', left) + randomString;
            var addedRightSpace = addedLeftSpace + new string(' ', right);
            return addedRightSpace;
        }

        public static int RandomInteger()
        {
            var r = new Random();
            var n = r.Next();
            return n;
        }
        public static float RandomFloat()
        {
            var r = new Random();
            float n = r.Next();
            return n;
        }

    }
}
