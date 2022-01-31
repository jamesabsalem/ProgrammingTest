namespace ProgrammingTest.Web.Data
{
    public class FileCreator: IFileCreator
    {
        private const string FileName = "WriteLines.txt";

        public async Task SaveAs<T>(IEnumerable<T>? data)
        {
            var name = string.Join(",", data.Select(x => x?.ToString()).ToArray());
            await File.WriteAllTextAsync(FileName, name);
        }

        public void Delete()
        {
            File.Delete(FileName);
        }
    }
}
