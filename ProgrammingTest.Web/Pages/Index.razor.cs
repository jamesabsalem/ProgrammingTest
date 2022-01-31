using System.Globalization;
using Microsoft.AspNetCore.Components;
using ProgrammingTest.Web.Data;

namespace ProgrammingTest.Web.Pages
{
    public partial class Index
    {
        private bool _isStart;
        private const int IntervalMilliseconds = 100;
        private int _integerCount;
        private int _stringCount;
        private int _floatCount;
        private  List<object> _listOfData = new();
        [Inject]
        protected IFileCreator? FileCreator { get; set; }


        public async Task onClick_btnStart()
        {
            await StartInterval();
        }

        private void Clear()
        {
            _integerCount = 0;
            _stringCount = 0;
            _floatCount = 0;
            _listOfData = new List<object>();
            FileCreator.Delete();
        }

        public void onClick_btnStop()
        {
            _isStart = false;
            FileCreator.Delete();
            if (_listOfData != null)
            {
                ExportToTextFile(_listOfData);
            }
        }
        private async Task StartInterval()
        {
            Clear();
            _isStart = true;
            while (_isStart)
            {
                await Task.Delay(IntervalMilliseconds);
                IntCounter();
                StringCounter();
                FloatCounter();

            }
        }

        private void IntCounter()
        {
            if (!_isStart) return;
            var randomInt = RandomGenerator.RandomInteger();
            _listOfData.Add(Convert.ToString(randomInt));
            _integerCount++;
        }

        private void StringCounter()
        {
            if (!_isStart) return;
            var randomString = RandomGenerator.RandomString(10);
            _listOfData.Add(randomString);
            _stringCount++;
        }

        private void FloatCounter()
        {
            if (!_isStart) return;
            var randomFloat = RandomGenerator.RandomFloat();
            _listOfData.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
            _floatCount++;
            StateHasChanged();
        }
        public async Task ExportToTextFile<T>(IEnumerable<T>? data)
        {
           await FileCreator!.SaveAs(data);
        }
    }
}
