using APIQLSV.Interfaces;

namespace APIQLSV.Models.Base
{
    public class BaseModels
    {
    }
    public class BaseMonHoc:IData
    {
        public virtual int MaMH { get; set; }
        public virtual string TenMH { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual IList<BaseDiem>? Diems { get; set; }
        public BaseMonHoc(int MaMon, string TenMH, int SoTiet)
        {
            this.MaMH = MaMon;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }
        public BaseMonHoc()
        {

        }
        public virtual MonHoc Convert()
        {
            return new MonHoc(this.MaMH, this.TenMH, this.SoTiet);  
        }
    }
    public class BaseDiem: IData
    {
        public virtual int MaSV { get; set; }
        public virtual int MaMH { get; set; }
        public virtual double DiemQT { get; set; }
        public virtual double DiemTP { get; set; }
        //public virtual MonHoc MonHoc { get; set; }
        public BaseDiem()
        {

        }
        public BaseDiem(int Masv, int Mamh, double diemtp, double diemqt)
        {
            this.MaSV = Masv;
            this.MaMH = Mamh;
            this.DiemTP = diemtp;
            this.DiemQT = diemqt;
        }
        public override bool Equals(object? obj)
        {
            return obj is BaseDiem diem &&
                   MaSV == diem.MaSV &&
                   MaMH == diem.MaMH &&
                   DiemQT == diem.DiemQT &&
                   DiemTP == diem.DiemTP;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MaSV, MaMH, DiemQT, DiemTP);
        }
    }
    public class BaseSinhVien: IData
    {
        public virtual string TenSV { get; set; }
        public virtual int MaSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }
        public virtual IList<BaseDiem> Diems { get; set; }
        public BaseSinhVien()
        {

        }
        public BaseSinhVien(string Ten, int MaSV, string GioiTinh, DateTime DOB, string Lop, string Khoa)
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