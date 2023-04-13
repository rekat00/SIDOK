using SIDOK.Models;
using SIDOK.Models.DTO;

namespace SIDOK.Repository.Interfaces
{
    public interface ISpesialisasiRepository
    {
        Task<IEnumerable<Spesialisasi>>SelectSpesialisasi(); 
    }
}
