using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Linea
{
    public class EditModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public EditModel(proyectoIngSoftware.Data.ApplicationDbContext context)
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

            var lineas =  await _context.Lineas.FirstOrDefaultAsync(m => m.IdLinea == id);
            if (lineas == null)
            {
                return NotFound();
            }
            Lineas = lineas;
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

            _context.Attach(Lineas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineasExists(Lineas.IdLinea))
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

        private bool LineasExists(int id)
        {
            return _context.Lineas.Any(e => e.IdLinea == id);
        }
    }
}
