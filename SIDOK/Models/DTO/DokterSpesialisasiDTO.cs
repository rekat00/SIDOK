using Microsoft.AspNetCore.Mvc.Rendering;

namespace SIDOK.Models.DTO
{
    public class DokterSpesialisasiDTO : Dokter
    {
        public int IdSpesialisasi { get; set; }
        public string? Spesialisasi { get; set; }       
        public SelectList? ListSpesialisasi { get; set; }
        public string? JenisKelaminString { get; set; }
        
    }
}
