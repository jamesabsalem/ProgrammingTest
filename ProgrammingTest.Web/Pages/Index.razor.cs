using System.Globalization;
using Microsoft.AspNetCore.Components;
using ProgrammingTest.Web.Helper;
using ProgrammingTest.Web.Models;
using ProgrammingTest.Web.Repository.IRepository;

namespace ProgrammingTest.Web.Pages
{
    public partial class Index
    {
        private bool _isStart;
        private const int IntervalMilliseconds = 1;
        private DataCount InputDataCount { get; set; } = new ();
        private DataCount OutPutDataCount { get; set; } = new ();
        private long _fileSize;
        private string _modalDisplay = "none";
        private List<DataTypeModel> _getData = new();

        private SubmitModel _submitModel { get; } = new ();


        [Inject]
        protected IFileRepository FileRepository { get; set; }


        // click start button
        public async Task onClick_btnStart()
        {
            await StartInterval();
        }

        private void Clear()
        {
            InputDataCount = new DataCount();
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
                OutPutDataCount.IntegerCount = data.Count(d => d.TypeName == "Integer");
                OutPutDataCount.FloatCount = data.Count(d => d.TypeName == "Float");
                OutPutDataCount.StringCount = data.Count(d => d.TypeName == "Alphanumeric");
                ModelDisplay(true);
            }
           
        }

        protected override void OnInitialized()
        {
            FileRepository.Delete();
        }

        private async Task StartInterval()
        {
            Clear();
            _isStart = true;
            var fileSize = Convert.ToInt16(_submitModel.FileSize);
            var fileSizeByte = fileSize * 1024;
            while (_isStart & (_fileSize < fileSizeByte))
            {
                await Task.Delay(IntervalMilliseconds);
                var random = new Random();
                var dataType = random.Next(1, 4);
                RandomGenerate(dataType);
                _fileSize = await FileRepository.SizeCheck();
                StateHasChanged();
            }
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
            var percentage = InputDataCount.IntegerPercentage;
            if (_submitModel.IntPercentage > 0)
            {
                if (!(percentage <= _submitModel.IntPercentage)) return;
                var randomInt = RandomGenerator.RandomInteger();
                FileRepository.Add(Convert.ToString(randomInt));
                InputDataCount.IntegerCount++;
            }
            else
            {
                var randomInt = RandomGenerator.RandomInteger();
                FileRepository.Add(Convert.ToString(randomInt));
                InputDataCount.IntegerCount++;
            }
            
        }

        private void StringCounter()
        {
            var percentage = InputDataCount.StringPercentage;
            if (_submitModel.StringPercentage > 0)
            {
                if (!(percentage <= _submitModel.StringPercentage)) return;
                var randomString = RandomGenerator.RandomString(10);
                FileRepository.Add(randomString);
                InputDataCount.StringCount++;
            }
            else
            {
                var randomString = RandomGenerator.RandomString(10);
                FileRepository.Add(randomString);
                InputDataCount.StringCount++;
            }
            
        }
        private void FloatCounter()
        {
            var percentage = InputDataCount.FloatPercentage;
            if (_submitModel.FloatPercentage > 0)
            {
                if (!(percentage <= _submitModel.FloatPercentage)) return;
                var randomFloat = RandomGenerator.RandomFloat();
                FileRepository.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
                InputDataCount.FloatCount++;
            }
            else
            {
                var randomFloat = RandomGenerator.RandomFloat();
                FileRepository.Add(Convert.ToString(randomFloat, CultureInfo.InvariantCulture));
                InputDataCount.FloatCount++;
            }
            
        }
        private void Close_OnClick()
        {
            ModelDisplay(false);
        }

        private void ModelDisplay(bool isShow)
        {
            _modalDisplay = isShow ? "block" : "none";
        }
    }
}
