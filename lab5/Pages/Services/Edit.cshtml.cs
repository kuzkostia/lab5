using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly OrderContext _context;

        public EditModel(OrderContext context)
        {
            _context = context;
        }
        public List<Services> Services { get; set; } = null!;
        public void OnGet()
        {
            Services = _context.Services.ToList();
        }
    }
}
