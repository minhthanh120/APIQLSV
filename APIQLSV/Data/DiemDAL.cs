using APIQLSV.Interfaces;
using APIQLSV.Models.Base;
using APIQLSV.Services;

namespace APIQLSV.Data
{
    public class DiemDAL // : IModelDAL<Diem>
    {
        public DiemDAL()
        {

        }
        public Diem Update(Diem diem)
        {
            Diem temp = new Diem();
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(diem);
                    tx.Commit();
                    temp = diem;
                }
                return diem;
            }
        }
        public Diem Create(Diem diem)
        {
            Diem temp = new Diem();
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(diem);
                    tx.Commit();
                    temp = diem;
                }
            }
            return temp;
        }
        public void Delete(int x)
        {
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var diem = session.Get<Diem>(x);
                    session.Delete(diem);
                    tx.Commit();
                }
            }
            //return true;
        }

        public bool IsExist(int x)
        {
            throw new NotImplementedException();
        }

        public List<Diem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Diem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Diem> GetPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<Diem> Search(string x, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
