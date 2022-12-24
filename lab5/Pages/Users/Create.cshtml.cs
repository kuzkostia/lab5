using lab5.Models;
using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly OrderContext _context;
        [BindProperty]
        public Users? users { get; set; }
        public CreateModel(OrderContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
