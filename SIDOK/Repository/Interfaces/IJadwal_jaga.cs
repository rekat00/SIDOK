using SIDOK.Models;

namespace SIDOK.Repository.Interfaces
{
    public interface IJadwal_jaga
    {
        public Task<int> Insert(Dokter dokter);
        public Task<bool> Update(Dokter dokter, int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<Dokter>> SelectAll();
        public Task<Dokter> SelectById(int id);
    }
}
