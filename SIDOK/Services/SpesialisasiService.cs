using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;
using SIDOK.Services.Interfaces;

namespace SIDOK.Services
{
    public class SpesialisasiService : ISpesialisasiService
    {
        private readonly ISpesialisasiRepository _spesialisasiRepository;
        public SpesialisasiService(ISpesialisasiRepository spesialisasiRepository) { _spesialisasiRepository = spesialisasiRepository; }

        public Task<IEnumerable<Spesialisasi>> SelectSpesialisasi() { 
            return _spesialisasiRepository.SelectSpesialisasi();
        }
    }
}
