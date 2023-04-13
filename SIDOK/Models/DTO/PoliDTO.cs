namespace SIDOK.Models.DTO
{
    public class PoliDTO:Poli
    {
        public int IdJadwal { get; set; }
        public string? Hari { get; set; }
        public int IdDokter { get; set;}
        public string? NamaDokter { get; set; }

    }
}
