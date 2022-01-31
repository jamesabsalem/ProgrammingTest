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
        private bool _enableGenerateButton = false;
        private string _modalDisplay = "none";
        private List<DataTypeModel> _getData = new();
        private double _integerPercentage;
        private double _floatPercentage;
        private double _stringPercentage;
        private SubmitModel _submitModel { get; set; } = new ();


        [Inject]
        protected IFileRepository FileRepository { get; set; }

        // click start button
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
            FileRepository.Delete();
        }
        // click stop button
        public void onClick_btnStop()
        {
            _isStart = false;
        }
        // click generate button 
        public async Task onClick_btnGenerate()
        {
            var data = await FileRepository.GetAll();
            _getData = data.Take(20).ToList();
            var totalCount = data.Count;
            if (totalCount > 0)
            {
                var intCount = data.Count(d => d.TypeName == "Integer");
                var floatCount = data.Count(d => d.TypeName == "Float");
                var stringCount = data.Count(d => d.TypeName == "Alphanumeric");
                _integerPercentage = Math.Round((float)intCount / (float)totalCount * 100);
                _floatPercentage = Math.Round((float)floatCount / (float)totalCount * 100);
                _stringPercentage = Math.Round((float)stringCount / (float)totalCount * 100);
                _modalDisplay = "block";
            }
           
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
                _fileSize = await FileRepository.SizeCheck();
                StateHasChanged();
            } while (_isStart & (_fileSize < fileSizeByte));
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
            FileRepository.Add(Convert.ToString(randomInt));
            _integerCount++;
        }

        private void StringCounter()
        {
            var randomString = RandomGenerator.RandomString(10);
            FileRepository.Add(randomString);
            _stringCount++;
        }

        private void FloatCounter()
        {
            var randomFloat = RandomGenerator.RandomFloat();
            FileRepository.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
            _floatCount++;
        }
        private void Close_OnClick()
        {
            _modalDisplay = "none";
        }
    }
}
