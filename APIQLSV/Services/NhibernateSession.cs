using NHibernate;
using NHibernate.Cfg;
using ISession = NHibernate.ISession;

namespace APIQLSV.Services
{
    public class NhibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(@"C:\Users\MinhThanh\source\repos\APIQLSV\APIQLSV\Models\hibernate.cfg.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\APIQLSV\APIQLSV\Mappings\Models.hbn.xml");
            configuration.AddFile(@"C:\Users\MinhThanh\source\repos\APIQLSV\APIQLSV\Mappings\DTO.hbn.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
