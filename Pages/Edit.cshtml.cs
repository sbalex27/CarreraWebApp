using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarreraWebApp.Data;
using CarreraWebApp.Models;

namespace CarreraWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly CarreraWebApp.Data.CarreraWebAppContext _context;

        public EditModel(CarreraWebApp.Data.CarreraWebAppContext context)
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

            var participante =  await _context.Participante.FirstOrDefaultAsync(m => m.Id == id);
            if (participante == null)
            {
                return NotFound();
            }
            Participante = participante;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(Participante.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParticipanteExists(int id)
        {
          return (_context.Participante?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
