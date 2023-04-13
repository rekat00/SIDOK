using SIDOK.Models;
using SIDOK.Repository.Interfaces;
using SIDOK.Services.Interfaces;

namespace SIDOK.Services
{
    public class PoliService : IPoliServices
    {
        private readonly IPoliRepository _poliRepository;
        public PoliService(IPoliRepository poliRepository)
        {
            _poliRepository = poliRepository;
        }

        public Task<int> Insert(Poli poli) { return _poliRepository.Insert(poli); }
        public Task<bool> Update(Poli poli, int id) { return _poliRepository.Update(poli, id); }
        public Task<bool> Delete(int id) { return _poliRepository.Delete(id); }
        public Task<IEnumerable<Poli>> SelectAll() { return _poliRepository.SelectAll(); }
        public Task<Poli> SelectById(int id) { return _poliRepository.SelectById(id); }
    }
}
