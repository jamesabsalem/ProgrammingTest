namespace ProgrammingTest.Web.Data
{
    public interface IFileRepository
    {
        Task Add(string item);
        void Delete();
        Task<long> SizeCheck();
        Task<List<DataTypeModel>> GetAll();
    }
}
