using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GameMasster.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Gamemasster game, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Game.Id == game.Id)
            .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Gamemasster game) =>
        Lines.RemoveAll(l => l.Game.Id == game.Id);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Game.Price * e.Quantity);
        public void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Gamemasster Game { get; set; }
        public int Quantity { get; set; }
    }
}