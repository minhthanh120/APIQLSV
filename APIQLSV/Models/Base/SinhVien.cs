using APIQLSV.Interfaces;

namespace APIQLSV.Models.Base
{
    public class SinhVien : IData
    {
        //Model Sinh viên
        public virtual string TenSV { get; set; }
        public virtual int MaSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }
        public virtual IList<Diem>? Diems { get; set; }
        public SinhVien()
        {
            this.Diems = new List<Diem>();
        }
        public SinhVien(string Ten, int MaSV, string GioiTinh, DateTime DOB, string Lop, string Khoa)
        {
            this.TenSV = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
    }
}

