namespace ProgrammingTest.Web.Data
{
    public class RandomGenerator
    {

        public static string RandomString(int length)
        {
            Random Random = new();
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
