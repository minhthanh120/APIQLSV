using APIQLSV.Interfaces;

namespace APIQLSV.Models.Base
{
    public class PagedResult
    {
        public int total { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public IList<SinhVien> list { get; set; }
    }
}
