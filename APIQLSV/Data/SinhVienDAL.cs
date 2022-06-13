using APIQLSV.Interfaces;
using APIQLSV.Models.Base;
using APIQLSV.Services;
using PagedList;
using ISession = NHibernate.ISession;
namespace APIQLSV.Data
{
    public class SinhVienDAL : IModelDAL<SinhVien>
    {
        public SinhVienDAL()
        {

        }
        public SinhVien Create(SinhVien sv)
        {
            SinhVien temp= new SinhVien();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                using (var tx = session.BeginTransaction())
                {
                    //session.CreateSQLQuery("SET IDENTITY_INSERT dbo.SINHVIEN ON").UniqueResult();
                    session.Save(sv);
                    tx.Commit();
                    temp = sv;
                    //session.CreateSQLQuery("SET IDENTITY_INSERT dbo.SINHVIEN OFF").UniqueResult();
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
                    var sv = session.Get<SinhVien>(x);
                    session.Delete(sv);
                    tx.Commit();
                }
            }
            //return true;
        }

        public SinhVien Update(SinhVien sv)
        {
            SinhVien temp = new SinhVien();
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(sv);
                    tx.Commit();
                    temp = sv;
                }
            }
            return temp;
        }
        public bool IsExist(int x)
        {
            bool exist;
            using (var session = NhibernateSession.OpenSession())
            {
                exist = session.Query<SinhVien>().Any(sv => sv.MaSV == x);
            }
            return exist;
        }

        public List<SinhVien> GetAll()
        {
            List<SinhVien> sv = new List<SinhVien>();
            using (var session = NhibernateSession.OpenSession())
            {
                sv = session.Query<SinhVien>().ToList();
            }
            return sv;
        }

        public SinhVien GetById(int id)
        {
            SinhVien sv = new SinhVien();
            using (var session = NhibernateSession.OpenSession())
            {
                sv = session.Get<SinhVien>(id);
            }
            return sv;
        }

        public List<SinhVien> GetPage(int page, int pageSize)
        {
            List<SinhVien> sv = new List<SinhVien>();
            using (var session = NhibernateSession.OpenSession())
            {
                sv = session.Query<SinhVien>().ToPagedList(page, pageSize).ToList();
            }
            return sv;
        }

        public List<SinhVien> Search(string x)
        {
            throw new NotImplementedException();
        }
    }
}
