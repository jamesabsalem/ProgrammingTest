using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProgrammingTest.Web.Data;

namespace ProgrammingTest.Web.Pages
{
    public partial class Index
    {
        private int counter = 0;
        private bool isStart = false;
        private int intervalMilliseconds = 100;
        private int integerCount = 0;
        private int stringCount = 0;
        private int floatCount = 0;
        private List<object> ListOfData = new();
        public static string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\file.txt";


        public async Task onClick_btnStart()
        {
            await StartInterval();
        }


        public void onClick_btnStop()
        {
            isStart = false;
            if (ListOfData.Count > 0)
            {
                ExportToTextFile(ListOfData, "James", ',');
            }
        }
        private async Task StartInterval()
        {
            isStart = true;
            while (isStart)
            {
                await Task.Delay(intervalMilliseconds);
                IntCounter();
                StringCounter();
                FloatCounter();

            }
        }

        private void IntCounter()
        {
            if (!isStart) return;
            var randomInt = RandomGenerator.RandomInteger();
            ListOfData.Add(Convert.ToString(randomInt));
            integerCount++;
        }

        private void StringCounter()
        {
            if (!isStart) return;
            var randomString = RandomGenerator.RandomString(10);
            ListOfData.Add(randomString);
            stringCount++;
        }

        private void FloatCounter()
        {
            if (!isStart) return;
            var randomFloat = RandomGenerator.RandomFloat();
            ListOfData.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
            floatCount++;
            StateHasChanged();
        }
        public void ExportToTextFile<T>(IEnumerable<T> data, string fileName, char columnSeparator)
        {
            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}
            //using var sw = File.CreateText(fileName);
            //sw.WriteLine(string.Join(",", data.Select(x => x.ToString()).ToArray()));
            saveFile(string.Join(",", data.Select(x => x.ToString()).ToArray()));
        }
        public void saveFile(string name)
        {


            // Save File to .txt  
            FileStream fParameter = new FileStream(dirParameter, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(name);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }
    }
}
