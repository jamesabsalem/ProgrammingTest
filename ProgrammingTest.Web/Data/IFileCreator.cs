namespace ProgrammingTest.Web.Data
{
    public interface IFileCreator
    {
        Task SaveAs<T>(IEnumerable<T>? data);
        void Delete();
    }
}
