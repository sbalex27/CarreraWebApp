using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarreraWebApp.Data;
using CarreraWebApp.Models;

namespace CarreraWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CarreraWebApp.Data.CarreraWebAppContext _context;

        public CreateModel(CarreraWebApp.Data.CarreraWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Participante Participante { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Participante == null || Participante == null)
            {
                return Page();
            }

            _context.Participante.Add(Participante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
