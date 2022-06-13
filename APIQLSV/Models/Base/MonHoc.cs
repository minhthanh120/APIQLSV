using APIQLSV.Interfaces;

namespace APIQLSV.Models.Base
{
    public class MonHoc: IData
    {
        //Model Môn học
        public virtual int MaMH { get; protected set; }
        public virtual string TenMH { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual IList<BaseDiem>? Diems { get; protected set; }
        public MonHoc()
        {
            //this.Diems = new List<Diem>();
        }
        public MonHoc(int MaMon, string TenMH, int SoTiet)
        {
            this.MaMH = MaMon;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }
        public virtual BaseMonHoc Convert()
        {
            return new BaseMonHoc(this.MaMH, this.TenMH, this.SoTiet);
        }
    }
}

