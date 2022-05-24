using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace GameMasster.Models
{
    public class GameGenreViewModel
    {
        public List<Gamemasster>? Game { get; set; }
        public SelectList? Genres { get; set; }
        public string? GameGenre { get; set; }
        public string? SearchString { get; set; }
    }
}