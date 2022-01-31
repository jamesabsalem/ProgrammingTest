namespace ProgrammingTest.Web.Data
{
    public interface IFileCreator
    {
        Task Add(string item);
        void Delete();
        Task<long> SizeCheck();
    }
}
