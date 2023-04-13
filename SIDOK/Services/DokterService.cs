using Microsoft.Identity.Client;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;
using SIDOK.Services.Interfaces;
using System.Globalization;

namespace SIDOK.Services
{
    public class DokterService : IDokterService
    {
        private readonly IDokterRepository _dokterRepository;
        public DokterService(IDokterRepository dokterRepository)
        {
            _dokterRepository = dokterRepository;
        }

        public Task<int> Insert(DokterSpesialisasiDTO dokter) 
        {

            dokter.Jenis_kelamin = Convert.ToInt32(dokter.Jenis_kelamin);
            return _dokterRepository.Insert(dokter);
        }
        public Task<bool> Update(DokterSpesialisasiDTO dokter, int id) { return _dokterRepository.Update(dokter, id); }
        public Task<bool> Delete(int id) { return _dokterRepository.Delete(id); }
        public Task<IEnumerable<DokterSpesialisasiDTO>> SelectAll() 
        { 
            return _dokterRepository.SelectAll(); 
        }
        public Task<DokterSpesialisasiDTO> SelectById(int id) { return _dokterRepository.SelectById(id); }
        //public Task<CariDokterDTO> CariDOkter(int idSpesialis, int idPoli) { return _dokterRepository.CariDokter(idSpesialis, idPoli); }
    }
}
