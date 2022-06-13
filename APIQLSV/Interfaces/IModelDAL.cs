using APIQLSV.Models.Base;

namespace APIQLSV.Interfaces
{
    public interface IModelDAL<T>
    {
        T Create(T obj);
        void Delete(int x);
        bool IsExist(int x);
        T Update(T obj);
        List<T> GetAll();
        T GetById(int id);
        List<T> GetPage(int page, int pageSize);
        List<T> Search(string x);
    }
}