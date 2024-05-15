using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Estacion
{
    public class DeleteModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public DeleteModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estaciones Estaciones { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estaciones = await _context.Estaciones.FirstOrDefaultAsync(m => m.IdEstacion == id);

            if (estaciones == null)
            {
                return NotFound();
            }
            else
            {
                Estaciones = estaciones;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estaciones = await _context.Estaciones.FindAsync(id);
            if (estaciones != null)
            {
                Estaciones = estaciones;
                _context.Estaciones.Remove(Estaciones);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
