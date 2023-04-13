using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Repository.Interfaces;
using System.Data;

namespace SIDOK.Repository
{
    public class DokterRepository: IDokterRepository
    {
        private string? _connection;
        public DokterRepository(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("SidokContext");
        }

        public async Task<int> Insert(DokterSpesialisasiDTO dokter)
        {
            using (var connection = new SqlConnection(_connection))
            {
                //Stored Procedure
                var procedure = "add_Dokter";
                //Value yang di input
                var value = new {Nama = dokter.Nama,Nik = dokter.Nik, Tanggal_lahir = dokter.Tanggal_lahir, Tempat_lahir = dokter.Tempat_lahir,Jenis_kelamin = dokter.Jenis_kelamin,Id_spesialisasi = dokter.IdSpesialisasi };

                var result = await connection.QueryAsync(procedure,value, commandType: CommandType.StoredProcedure);

                return 1;
            }
        }

        public async Task<bool> Update(DokterSpesialisasiDTO dokter, int id)
        {
            //UPDATE JUGA KALAU MAU TAMBAH SP NIP
            using (var connection = new SqlConnection(_connection))
            {

                //Stored Procedure
                var procedure = "Update_Dokter";
                //Value yang di input
                var value = new { Nama = dokter.Nama, Nik = dokter.Nik, Tanggal_lahir = dokter.Tanggal_lahir, Tempat_lahir = dokter.Tempat_lahir, Jenis_kelamin = dokter.Jenis_kelamin, id_spesialisasi = dokter.IdSpesialisasi,id_update = id};

                var result = await connection.QueryAsync(procedure, value, commandType: CommandType.StoredProcedure);

            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                await connection.QueryAsync("DELETE FROM SPESIALISASI_DOKTER WHERE id_dokter = @id", new { Id = id });
                await connection.QueryAsync("DeLETE FROM [JADWAL JAGA] WHERE id_dokter = @id", new { Id = id });
                await connection.QueryAsync("DELETE FROM DOKTER Where id = @id", new { Id = id });

               
            }
            return true;
        }
            
        public async Task<IEnumerable<DokterSpesialisasiDTO>> SelectAll()
        {
            using (var connection = new SqlConnection(_connection))
            {
                var dokter = await connection.QueryAsync<DokterSpesialisasiDTO>("SELECT D.id,SD.id_spesialisasi as IdSpesialisasi,D.nama,D.nip,D.nik,D.tempat_lahir,D.tanggal_lahir," +
                    "D.jenis_kelamin,S.nama as spesialisasi FROM DOKTER" +
                    " D LEFT JOIN SPESIALISASI_DOKTER SD ON D.id = SD.id_dokter" +
                    " LEFT JOIN SPESIALISASI S ON S.id= SD.id_spesialisasi");
                return dokter;
            }
        }

        public async Task<DokterSpesialisasiDTO> SelectById(int id)
        {
            using (var connection = new SqlConnection(_connection))
            {
                var dokter = await connection.QueryFirstOrDefaultAsync<DokterSpesialisasiDTO>("SELECT D.id, D.nama,D.nip,D.nik,D.tempat_lahir,D.tanggal_lahir,D.jenis_kelamin,S.nama as spesialisasi, S.id as IdSpesialisasi FROM DOKTER D LEFT JOIN SPESIALISASI_DOKTER SD ON D.id = SD.id_dokter LEFT JOIN SPESIALISASI S ON S.id= SD.id_spesialisasi where D.id = @id", new { Id = id });

                return dokter;
            }
        }

        //public async Task<CariDokterDTO> CariDokter(int idSpesialis, int idPoli) 
        //{


            //using (var connection = new SqlConnection(_connection))
            //{
            //    var dokter = await connection.QueryFirstOrDefaultAsync<CariDokterDTO>("SELECT D.id, D.nama,D.nip,D.nik,D.tempat_lahir,D.tanggal_lahir,D.jenis_kelamin, S.id as IdSpesialis FROM DOKTER D " +
            //        "LEFT JOIN SPESIALISASI_DOKTER SD ON D.id = SD.id_dokter " +
            //        "LEFT JOIN SPESIALISASI S ON S.id= SD.id_spesialisasi " +
            //        "LEFT JOIN [JADWAL JAGA] JJ ON JJ.id_dokter = D.id " +
            //        "where S.id = @idSpesialis AND JJ.id_poli = @idPoli", new { IdSpesialis = idSpesialis,IdPoli = idPoli});

            //    return dokter;
            //}
        //}


    }
}
