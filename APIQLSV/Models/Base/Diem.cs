using APIQLSV.Interfaces;
using APIQLSV.Models.DTO;

namespace APIQLSV.Models.Base
{
    public class Diem: IData
    {
        //Model Điểm
        public virtual int MaSV { get; set; }
        //public virtual int MaMH { get; set; }
        public virtual double DiemQT { get; set; }
        public virtual double DiemTP { get; set; }
        //public virtual BaseSinhVien? sinhvien { get; protected set; }
        public virtual BaseMonHoc? monhoc { get; set; }
        public Diem() { }
        public Diem(MonHocDTO diem, int masv)
        {
            //this.MaMH = diem.MaMH; this.MaSV = masv; 
            this.DiemTP = diem.DiemTP; this.DiemQT = diem.DiemQT;
        }
        public override bool Equals(object obj)
        {
            return obj is Diem diem &&
                    //MaSV == diem.MaSV &&
                    //MaMH == diem.MaMH &&
                    DiemQT == diem.DiemQT &&
                    DiemTP == diem.DiemTP;
        }

        public override int GetHashCode()
        {
            int hashCode = 636515174;
            // hashCode = hashCode * -1521134295 + MaSV.GetHashCode();
            //hashCode = hashCode * -1521134295 + MaMH.GetHashCode();
            hashCode = hashCode * -1521134295 + DiemQT.GetHashCode();
            hashCode = hashCode * -1521134295 + DiemTP.GetHashCode();
            return hashCode;
        }
    }
}
