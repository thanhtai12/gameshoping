using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameMasster.MyTagHelper;
using GameMasster.Models;
using System.Linq;


namespace BooksStore.Pages
{

    public class MyCartModel : PageModel
    {
        [BindProperty]
        public ProductViewModel Product {get; set;}

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
            public string Rating { get; set; }
            public string Link { get; set; }
        }

        public void OnGet()
        {

        }
        private MyGameRepository repository;
        public MyCartModel(MyGameRepository repo)
        {
            repository = repo;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
        }
        public IActionResult OnPost(long gameId, string returnUrl)
        {
            Gamemasster game = repository.Games
            .FirstOrDefault(b => b.Id == gameId);
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
            myCart.AddItem(game, 1);
            HttpContext.Session.SetJson("mycart", myCart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}