using Dapper;
using Microsoft.Data.SqlClient;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;

namespace SIDOK.Repository
{
    public class JadwalRepository :IJadwalRepository
    {
        private string? _connection;
        public JadwalRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("SidokContext");
        }

        public async Task<int> Insert(Jadwal_jaga jadwal)
        {

            using (var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync("INSERT INTO [JADWAL JAGA] " +
                    "(hari,id_poli,id_dokter)" +
                  " VALUES(@Hari,@Id_poli,@Id_dokter)", jadwal);
                return 1;
            }

        }

        public async Task<int> Tambah(PoliDTO jadwal,int id)
        {

            using (var connection = new SqlConnection(_connection))
            {
                jadwal.IdDokter = id;
                var result = await connection.QueryAsync("INSERT INTO [JADWAL JAGA] " +
                  "(hari,id_poli,id_dokter)" +
                  " VALUES(@Hari,@IdPoli,@IdDokter) " , jadwal);
                return 1;
            }

        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.QueryAsync("DELETE FROM [JADWAL JAGA] Where id = @id", new { Id = id });
            }
            return true;
        }

        public async Task<IEnumerable<PoliDTO>> SelectAll()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var jadwal = await connection.QueryAsync<PoliDTO>("SELECT JJ.id as IdJadwal,D.id as IdDokter ,"+
                    "D.nama as NamaDokter, P.nama as namaPoli,P.lokasi as LokasiPoli, JJ.hari as Hari FROM [JADWAL JAGA] JJ " +
                    "LEFT JOIN POLI P ON P.id = JJ.id_poli " +
                    "JOIN DOKTER D ON D.id = JJ.id_dokter");
                return jadwal;
            }
        }

        public async Task<IEnumerable<PoliDTO>> SelectAllByDoctorId(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var jadwal = await connection.QueryAsync<PoliDTO>("SELECT JJ.id as IdJadwal,D.id as IdDokter,P.id as IdPoli, " +
                    "D.nama as NamaDokter, P.nama as namaPoli,P.lokasi as LokasiPoli, JJ.hari as Hari FROM [JADWAL JAGA] JJ " +
                    "LEFT JOIN POLI P ON P.id = JJ.id_poli " +
                    "JOIN DOKTER D ON D.id = JJ.id_dokter " +
                    "WHERE D.id = @Id", new {Id = id });
                return jadwal;
            }
        }

        public async Task<IEnumerable<PoliDTO>> SelectAllByPoliId(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var jadwal = await connection.QueryAsync<PoliDTO>("SELECT JJ.id as IdJadwal,D.id as IdDokter , P.id as IdPoli, " +
                    "D.nama as NamaDokter, P.nama as namaPoli,P.lokasi as LokasiPoli, JJ.hari as Hari FROM [JADWAL JAGA] JJ " +
                    "LEFT JOIN POLI P ON P.id = JJ.id_poli " +
                    "JOIN DOKTER D ON D.id = JJ.id_dokter " +
                    "WHERE P.id = @Id", new{ Id = id});
                return jadwal;
            }
        }

        //SEARCH UNTUK MENAMPILKAN JADWAL
        public async Task<PoliDTO> SelectById(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var jadwal = await connection.QueryFirstOrDefaultAsync<PoliDTO>("SELECT JJ.id, D.nama as NamaDokter, " +
                    "JJ.hari as Hari, P.Nama as NamaPoli, P.lokasi as LokasiPoli " +
                    "FROM [JADWAL JAGA] JJ " +
                    "FULL JOIN POLI P ON P.id = JJ.id_poli " +
                    "FULL JOIN DOKTER D ON D.id = JJ.id_dokter WHERE JJ.id = @id", new { Id = id });

                return jadwal;
            }
        }

    }
}
