using APIQLSV.Models.DTO;

namespace APIQLSV.Interfaces

{
    public interface IRespository
    {
        SinhVienDTO Find(int masv);
        List<SinhVienDTO> GetAll();
        List<MonHocDTO> GetAll(int masv);
    }
}