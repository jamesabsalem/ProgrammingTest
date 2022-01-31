namespace ProgrammingTest.Web.Data
{
    public class FileCreator: IFileCreator
    {
        private const string FileName = "WriteLines.txt";

        public async Task Add(string item)
        {
            await using var file = File.AppendText(FileName);
            await file.WriteAsync(item + ",");
            file.Close();
        }

        public void Delete()
        {
            File.Delete(FileName);
        }

        public async Task<long> SizeCheck()
        {
             var bytes = await File.ReadAllBytesAsync(FileName);
             return bytes.Length;
        }
    }
}
