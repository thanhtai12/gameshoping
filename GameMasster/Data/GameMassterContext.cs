using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameMasster.Models;

namespace GameMasster.Data
{
    public class GameMassterContext : DbContext
    {
        public GameMassterContext (DbContextOptions<GameMassterContext> options)
            : base(options)
        {
        }

        public DbSet<GameMasster.Models.Gamemasster> Gamemasster { get; set; }
    }
}
