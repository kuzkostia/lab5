using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly OrderContext _context;

        public IndexModel(OrderContext context)
        {
            _context = context;
        }
        public List<Users> Users { get; set; } = null!;
        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
