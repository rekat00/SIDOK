using SIDOK.Models;
using SIDOK.Models.DTO;

namespace SIDOK.Services.Interfaces
{
    public interface ISpesialisasiService
    {
        Task<IEnumerable<Spesialisasi>> SelectSpesialisasi();

    }
}
