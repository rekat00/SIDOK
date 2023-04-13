using Dapper;
using Microsoft.Data.SqlClient;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;
using SIDOK.Services;

namespace SIDOK.Repository
{
    public class SpesialisasiRepository : ISpesialisasiRepository
    {
        private string? _connection;
        public SpesialisasiRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("SidokContext");
        }

        public async Task<IEnumerable<Spesialisasi>> SelectSpesialisasi() {

            using (var connection = new SqlConnection(_connection))
            {
                var poli = await connection.QueryAsync<Spesialisasi>("SELECT * FROM SPESIALISASI");
                return poli;
            }
        }

    }
}
