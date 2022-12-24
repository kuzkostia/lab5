using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Readers
{
    public class DeleteModel : PageModel
    {
        private readonly OrderContext _context;
        public Orders orders { get; set; }
        public Users? users { get; set; }
        public Services? services  { get; set; }
        public DeleteModel(OrderContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }
            users = _context.Users.First(p => p.Id == orders.UserID);
            services = _context.Services.First(p => p.Id == orders.ServiceID);

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var reader = await _context.Orders.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(reader);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
