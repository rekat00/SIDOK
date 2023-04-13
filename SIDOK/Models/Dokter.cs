using System.ComponentModel.DataAnnotations;

namespace SIDOK.Models
{
    public class Dokter
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public string? Nip { get; set; }
        public string? Nik { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Tanggal_lahir { get; set; }
        public string? Tempat_lahir { get; set; }
        public int Jenis_kelamin { get; set; }

    
    }
}
