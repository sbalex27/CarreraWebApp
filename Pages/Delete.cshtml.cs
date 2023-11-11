using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarreraWebApp.Data;
using CarreraWebApp.Models;

namespace CarreraWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CarreraWebApp.Data.CarreraWebAppContext _context;

        public DeleteModel(CarreraWebApp.Data.CarreraWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Participante Participante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Participante == null)
            {
                return NotFound();
            }

            var participante = await _context.Participante.FirstOrDefaultAsync(m => m.Id == id);

            if (participante == null)
            {
                return NotFound();
            }
            else 
            {
                Participante = participante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Participante == null)
            {
                return NotFound();
            }
            var participante = await _context.Participante.FindAsync(id);

            if (participante != null)
            {
                Participante = participante;
                _context.Participante.Remove(Participante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
