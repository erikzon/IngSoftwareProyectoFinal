using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Linea
{
    public class DeleteModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public DeleteModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lineas Lineas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineas = await _context.Lineas.FirstOrDefaultAsync(m => m.IdLinea == id);

            if (lineas == null)
            {
                return NotFound();
            }
            else
            {
                Lineas = lineas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineas = await _context.Lineas.FindAsync(id);
            if (lineas != null)
            {
                Lineas = lineas;
                _context.Lineas.Remove(Lineas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
