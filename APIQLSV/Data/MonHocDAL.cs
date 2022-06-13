using APIQLSV.Interfaces;
using APIQLSV.Models.Base;
using APIQLSV.Services;
using PagedList;

namespace APIQLSV.Data
{
    public class MonHocDAL : IModelDAL<BaseMonHoc>
    {
        public MonHocDAL()
        {

        }
        public BaseMonHoc Create(BaseMonHoc mh)
        {
            BaseMonHoc temp = new BaseMonHoc();
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    //session.CreateSQLQuery("SET IDENTITY_INSERT dbo.MONHOC ON").UniqueResult();
                    session.Save(mh);
                    tx.Commit();
                    //session.CreateSQLQuery("SET IDENTITY_INSERT dbo.MONHOC OFF").UniqueResult();
                    temp = mh;
                }
            }
            return temp;
        }

        public void Delete(int x)
        {
            if (IsExist(x))
            {
                using (var session = NhibernateSession.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var temp = session.Get<MonHoc>(x);
                        session.Delete(temp);
                        tx.Commit();
                    }
                }
            }
        }

        public BaseMonHoc Update(BaseMonHoc mh)
        {
            BaseMonHoc temp = new BaseMonHoc();
            if (IsExist(mh.MaMH)==false)
                return null;
            using (var session = NhibernateSession.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(mh);
                    tx.Commit();
                    temp = mh;
                }
            }
            return temp;
        }
        public bool IsExist(int x)
        {
            bool exist;
            using (var session = NhibernateSession.OpenSession())
            {
                exist = session.Query<BaseMonHoc>().Any(mh => mh.MaMH == x);
            }
            return exist;
        }

        public List<BaseMonHoc> GetAll()
        {
            List<BaseMonHoc> mh = new List<BaseMonHoc>();
            using (var session = NhibernateSession.OpenSession())
            {
                mh = session.Query<BaseMonHoc>().ToList();
            }
            return mh;
        }

        public BaseMonHoc GetById(int id)
        {
            if (!IsExist(id))
                return null;
            BaseMonHoc mh = new BaseMonHoc();
            using (var session = NhibernateSession.OpenSession())
            {
                mh = session.Get<BaseMonHoc>(id);
            }
            return mh;
        }

        public List<BaseMonHoc> GetPage(int page, int pageSize)
        {

            List<BaseMonHoc> mh = new List<BaseMonHoc>();
            using (var session = NhibernateSession.OpenSession())
            {
                mh = session.Query<BaseMonHoc>().ToPagedList(page, 5).ToList();
            }
            return mh;
        }
        public List<BaseMonHoc> Search(string x)
        {
            List<BaseMonHoc> mh = new List<BaseMonHoc>();
            if (x.Length > 1)
            {
                using (var session = NhibernateSession.OpenSession())
                {
                    mh = session.Query<BaseMonHoc>().Where(mh => mh.TenMH.Contains(x)).ToList();
                }
            }
            return mh;
        }
    }
}
