using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GameMasster.Data;
using System;
using System.Linq;


namespace GameMasster.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameMassterContext(serviceProvider.GetRequiredService<DbContextOptions<GameMassterContext>>()))
            {
                if (context.Gamemasster.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.Gamemasster.AddRange(
                new Gamemasster
                {
                    Title = "Assassin Creed Rogue",
                    ReleaseDate = DateTime.Parse("2018-10-16"),
                    Genre = "Ubisoft",
                    Rating = "4*",
                    Link = ""
                },
                new Gamemasster
                {
                    Title = "Assassin Creed Revelution",
                    ReleaseDate = DateTime.Parse("2021-8-3"),
                    Genre = "Ubisoft",
                    Rating="4*",
                    Link = ""
                }
                ); ; ;
                context.SaveChanges();
                }

        }
    }
}
