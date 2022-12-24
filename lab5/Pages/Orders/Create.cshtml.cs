using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab5.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly OrderContext _context;
        public Orders orders { get; set; }
        public SelectList UsersList { get; set; } = null!;
        public SelectList ServicesList { get; set; } = null!;
        public CreateModel(OrderContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            UsersList = new SelectList(_context.Users, "Id", "Name");
            ServicesList = new SelectList(_context.Services, "Id", "Name");
        }
        public async Task<IActionResult> OnPostAsync(Orders orders)
        {
            if (orders.UserID != 0 && orders.ServiceID != 0)
            {
                _context.Orders.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            UsersList = new SelectList(_context.Users, "Id", "Name");
            ServicesList = new SelectList(_contextServices, "Id", "Name");
            return Page();
        }
    }
}
