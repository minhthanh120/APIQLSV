using APIQLSV.Ultilities;

namespace APIQLSV.Models.DTO
{
    public class MonHocDTO
    {
        //ViewModel Môn học
        public virtual int MaMH { get; set; }
        public virtual string TenMH { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual double DiemTP { get; set; }
        public virtual double DiemQT { get; set; }
        public virtual double DiemTK { get; set; }
        public virtual string DanhGia { get; set; }
        public MonHocDTO() { }
        public MonHocDTO(int MaMH, string TenMH, int SoTiet)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }
        public MonHocDTO(int MaMH, string TenMH, int SoTiet, double DiemQT, double DiemTP)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
            double diemtk = (DiemQT + DiemTP) / 2;
            this.DiemTK = diemtk;
            if (diemtk > ConstParamater.diemdat)
                this.DanhGia = "Đạt";
            else
                this.DanhGia = "Chưa đạt";
        }
    }
}
