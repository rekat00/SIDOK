namespace SIDOK.Models
{
    public class Jadwal_jaga
    {
        public int Id { get; set; }
        public string? Hari { get; set; }
        public int id_poli { get; set; }
        public int id_dokter { get; set; }
    }
}
