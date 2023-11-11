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
    public class IndexModel : PageModel
    {
        private readonly CarreraWebApp.Data.CarreraWebAppContext _context;

        public IndexModel(CarreraWebApp.Data.CarreraWebAppContext context)
        {
            _context = context;
        }

        public IList<Participante> Participante { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Participante != null)
            {
                Participante = await _context.Participante.ToListAsync();
            }
        }
    }
}
