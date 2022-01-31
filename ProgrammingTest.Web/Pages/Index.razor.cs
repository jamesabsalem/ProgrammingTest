using System.Globalization;
using Microsoft.AspNetCore.Components;
using ProgrammingTest.Web.Data;

namespace ProgrammingTest.Web.Pages
{
    public partial class Index
    {
        private bool _isStart;
        private const int IntervalMilliseconds = 5;
        private int _integerCount;
        private int _stringCount;
        private int _floatCount;
        private long _fileSize;
        private SubmitModel _submitModel { get; set; } = new ();
        [Inject]
        protected IFileCreator FileCreator { get; set; }


        public async Task onClick_btnStart()
        {
            await StartInterval();
        }

        private void Clear()
        {
            _integerCount = 0;
            _stringCount = 0;
            _floatCount = 0;
            _fileSize = 0;
            FileCreator.Delete();
        }

        public void onClick_btnStop()
        {
            _isStart = false;
        }
        private async Task StartInterval()
        {
            Clear();
            _isStart = true;
            var fileSize = Convert.ToInt16(_submitModel.FileSize);
            var fileSizeByte = fileSize * 1024;
            do
            {
                await Task.Delay(IntervalMilliseconds);
                var random = new Random();
                var dataType = random.Next(1, 4);
                RandomGenerate(dataType);
                _fileSize = await FileCreator.SizeCheck();
                StateHasChanged();
            } while (_isStart & _fileSize < fileSizeByte);
        }

        private void RandomGenerate(int number)
        {
            switch (number)
            {
                case (int)DataTypeEnum.IntType:
                    IntCounter();
                    break;
                case (int)DataTypeEnum.StringType:
                    StringCounter();
                    break;
                case (int)DataTypeEnum.FloatType:
                    FloatCounter();
                    break;
                
            }
        }
        private void IntCounter()
        {
            var randomInt = RandomGenerator.RandomInteger();
            FileCreator.Add(Convert.ToString(randomInt));
            _integerCount++;
        }

        private void StringCounter()
        {
            var randomString = RandomGenerator.RandomString(10);
            FileCreator.Add(randomString);
            _stringCount++;
        }

        private void FloatCounter()
        {
            var randomFloat = RandomGenerator.RandomFloat();
            FileCreator.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
            _floatCount++;
        }
    }
}
