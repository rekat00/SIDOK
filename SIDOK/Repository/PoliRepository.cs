using Dapper;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Data.SqlClient;
using SIDOK.Models;
using SIDOK.Repository.Interfaces;

namespace SIDOK.Repository
{
    public class PoliRepository :IPoliRepository
    {
        private readonly string? _connection;
        public PoliRepository(IConfiguration configuration) {
            _connection = configuration.GetConnectionString("SidokContext");
        }

        public async Task<int> Insert(Poli poli)
        {

            //KALAU SUDAH MAU GANTI NIP JANGAN LUPA UPDATE
            using (var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync("INSERT INTO POLI " +
                    "(nama,lokasi)" +
                  " VALUES(@NamaPoli,@LokasiPoli)", poli);
                return 1;
            }
        }

        public async Task<bool> Update(Poli poli, int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.ExecuteAsync("UPDATE POLI SET nama = @NamaPoli," +
                    "lokasi = @LokasiPoli WHERE id = " + id, poli);
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.QueryAsync("DeLETE FROM [JADWAL JAGA] WHERE id_poli = @id", new { Id = id });
                await connection.QueryAsync("DELETE FROM POLI Where id = @id", new { Id = id });

            }
            return true;
        }

        public async Task<IEnumerable<Poli>> SelectAll()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var poli = await connection.QueryAsync<Poli>("SELECT id as IdPoli, nama as NamaPoli, lokasi as LokasiPoli FROM POLI");
                return poli;
            }
        }

        public async Task<Poli> SelectById(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var poli = await connection.QueryFirstOrDefaultAsync<Poli>("SELECT  id as IdPoli, nama as NamaPoli, lokasi as LokasiPoli FROM POLI where id = @id", new { Id = id });

                return poli;
            }
        }
    }
}
