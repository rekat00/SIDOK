using SIDOK.Models;

namespace SIDOK.Repository.Interfaces
{
    public interface IPoliRepository
    {
        public Task<int> Insert(Poli poli);
        public Task<bool> Update(Poli poli, int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<Poli>> SelectAll();
        public Task<Poli> SelectById(int id);
    }
}
