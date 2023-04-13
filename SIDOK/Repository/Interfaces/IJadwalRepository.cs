using SIDOK.Models;
using SIDOK.Models.DTO;

namespace SIDOK.Repository.Interfaces
{
    public interface IJadwalRepository
    {
        public Task<int> Insert(Jadwal_jaga jadwal);
        public Task<int> Tambah(PoliDTO jadwal,int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<PoliDTO>> SelectAll();
        public Task<IEnumerable<PoliDTO>> SelectAllByPoliId(int id);
        public Task<IEnumerable<PoliDTO>> SelectAllByDoctorId(int id);
        public Task<PoliDTO> SelectById(int id);
    }
}
