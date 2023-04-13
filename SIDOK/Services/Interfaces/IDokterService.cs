using SIDOK.Models;
using SIDOK.Models.DTO;

namespace SIDOK.Services.Interfaces
{
    public interface IDokterService
    {
        public Task<int> Insert(DokterSpesialisasiDTO dokter);
        public Task<bool> Update(DokterSpesialisasiDTO dokter, int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<DokterSpesialisasiDTO>> SelectAll();
        public Task<DokterSpesialisasiDTO> SelectById(int id);
        //public Task<CariDokterDTO> CariDokter(int idSpesialis, int idPoli);
    }
}
