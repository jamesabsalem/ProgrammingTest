using System.ComponentModel.DataAnnotations;

namespace ProgrammingTest.Web.Models
{
    public class DataCount
    {
        public int IntegerCount { get; set; } = 0;
        public int FloatCount { get; set; } = 0;
        public int StringCount { get; set; }=0;

        public int TotalCount => IntegerCount + FloatCount + StringCount;
        public double IntegerPercentage => Percentage(IntegerCount,TotalCount);
        public double FloatPercentage => Percentage(FloatCount,TotalCount);
        public double StringPercentage => Percentage(StringCount,TotalCount);
        private static double Percentage(int count, int total)
        {
            if (total <= 0)
            {
                return 0;
            }
            return Math.Round(count / (float)total * 100);
        }
    }
}
