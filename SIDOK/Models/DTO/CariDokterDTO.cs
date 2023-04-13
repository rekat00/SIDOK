namespace SIDOK.Models.DTO
{
    public class CariDokterDTO: Dokter
    {
        public int IdPoli { get; set; }
        public int IdSpesialisasi { get; set; }
        public string? NamaPoli { get; set; }

        public string? NamaSpesialisasi { get; set; }
            
        
    }
}
