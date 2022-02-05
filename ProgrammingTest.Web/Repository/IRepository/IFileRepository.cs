using ProgrammingTest.Web.Models;

namespace ProgrammingTest.Web.Repository.IRepository
{
    public interface IFileRepository
    {
        Task Add(string item);
        void Delete();
        Task<long> SizeCheck();
        Task<List<DataTypeModel>> GetAll();
    }
}
