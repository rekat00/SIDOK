using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIDOK.Models;
using SIDOK.Models.DTO;

namespace SIDOK.Data
{
    public class SIDOK1Context : DbContext
    {
        public SIDOK1Context (DbContextOptions<SIDOK1Context> options)
            : base(options)
        {
        }

        public DbSet<SIDOK.Models.Poli> Poli { get; set; } = default!;

        public DbSet<SIDOK.Models.DTO.PoliDTO>? PoliDTO { get; set; }
    }
}
