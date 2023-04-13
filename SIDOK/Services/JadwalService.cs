using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;
using SIDOK.Services.Interfaces;

namespace SIDOK.Services
{
    public class JadwalService : IJadwalService
    {
        private readonly IJadwalRepository _jadwalRepository;
        public JadwalService(IJadwalRepository jadwalRepository) { _jadwalRepository = jadwalRepository; }

        public Task<int> Insert(Jadwal_jaga jadwal) { return _jadwalRepository.Insert(jadwal); }
        public Task<int> Tambah(PoliDTO jadwal, int id) { return _jadwalRepository.Tambah(jadwal,id); }
        public Task<bool> Delete(int id) {return _jadwalRepository.Delete(id); }
        public Task<IEnumerable<PoliDTO>> SelectAll() { return _jadwalRepository.SelectAll(); }
        public Task<IEnumerable<PoliDTO>> SelectAllByDoctorId(int id) { return _jadwalRepository.SelectAllByDoctorId(id); }
        public Task<IEnumerable<PoliDTO>> SelectAllByPoliId(int id) { return _jadwalRepository.SelectAllByPoliId(id); }
        public Task<PoliDTO> SelectById(int id) { return _jadwalRepository.SelectById(id); }


    }
}
