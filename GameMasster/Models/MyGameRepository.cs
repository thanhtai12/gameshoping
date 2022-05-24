using System.Linq;
namespace GameMasster.Models
{
    public interface MyGameRepository
    {
        IQueryable<Gamemasster> Games { get; set; }
    }
}