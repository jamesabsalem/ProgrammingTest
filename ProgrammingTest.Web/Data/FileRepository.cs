namespace ProgrammingTest.Web.Data
{
    public class FileRepository : IFileRepository
    {
        private const string Path = "WriteLines.txt";

        public async Task Add(string item)
        {
            await using var file = File.AppendText(Path);
            await file.WriteAsync(item + ",");
            file.Close();
        }

        public void Delete()
        {
            File.Delete(Path);
        }

        public async Task<long> SizeCheck()
        {
            var bytes = await File.ReadAllBytesAsync(Path);
            return bytes.Length;
        }

        public async Task<List<DataTypeModel>> GetAll()
        {
            if (!File.Exists(Path)) return new List<DataTypeModel>();
            var dataTypes = new List<DataTypeModel>();

            var readText = await File.ReadAllTextAsync(Path);
            var splitString = readText.Split(",");
            foreach (var item in splitString)
            {
                var dataType = new DataTypeModel();
                var trimmedItem = item.Trim();
                if (string.IsNullOrEmpty(trimmedItem)) continue;
                if (int.TryParse(trimmedItem, out _))
                {
                    dataType.TypeName = "Integer";
                    dataType.Data = trimmedItem;
                }
                else if (float.TryParse(trimmedItem, out _))
                {
                    dataType.TypeName = "Float";
                    dataType.Data = trimmedItem;

                }
                else
                {
                    dataType.TypeName = "Alphanumeric";
                    dataType.Data = trimmedItem;
                }
                dataTypes.Add(dataType);

            }
            return dataTypes;

        }
    }
}
