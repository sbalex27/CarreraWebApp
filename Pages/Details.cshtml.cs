﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly CarreraWebApp.Data.CarreraWebAppContext _context;

        public DetailsModel(CarreraWebApp.Data.CarreraWebAppContext context)
        {
            _context = context;
        }

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
    }
}
