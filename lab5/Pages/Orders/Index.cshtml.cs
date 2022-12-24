using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly OrderContext _context;

        public IndexModel(OrderContext context)
        {
            _context = context;
        }
        public List<Order> Orders { get; set; } = null!;
        public void OnGet()
        {
            Orders = _context.Orders.Include(prop => prop.User).Include(prop => prop.Service).ToList();
        }
    }
}
