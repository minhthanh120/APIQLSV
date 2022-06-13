using NHibernate;
using ISession = NHibernate.ISession;
using APIQLSV.Models.DTO;
using APIQLSV.Services;
using APIQLSV.Models.Base;
using APIQLSV.Interfaces;

namespace APIQLSV.Data
{
    public class Respository : IRespository
    {
        public Respository()
        {

        }
        public SinhVienDTO Find(int masv)
        {
            SinhVienDTO sv = new SinhVienDTO();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.GetNamedQuery("DANHSACHSINHVIEN");
                if (query.List<SinhVienDTO>().Any() != false)
                {
                    List<SinhVienDTO> SVs = query.List<SinhVienDTO>().ToList();
                    if (SVs != null)
                    {
                        sv = SVs.Find(x => x.MaSV == masv);
                        if (sv != null)
                        {
                            query = session.GetNamedQuery("DANHSACHDIEM");
                            query.SetParameter("param", masv, NHibernateUtil.Int32);
                            List<MonHocDTO> MHs = query.List<MonHocDTO>()
                                .ToList();
                            sv.MonHocDTOs = query.List<MonHocDTO>().ToList();
                        }
                    }
                }
            }
            return sv;
        }
        public List<SinhVienDTO> GetAll()
        {
            List<SinhVienDTO> SVs = new List<SinhVienDTO>();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.GetNamedQuery("DANHSACHSINHVIEN");
                SVs = query.List<SinhVienDTO>().ToList();
            }
            return SVs;
        }
        public List<MonHocDTO> GetAll(int masv)
        {
            List<MonHocDTO> MHs = new List<MonHocDTO>();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.GetNamedQuery("DANHSACHMONHOC");
                query.SetParameter("param", masv, NHibernateUtil.Int32);
                MHs = query.List<MonHocDTO>().ToList();
            }
            return MHs;
        }
    }
}
