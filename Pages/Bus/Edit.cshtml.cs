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

namespace proyectoIngSoftware.Pages.Bus
{
    public class EditModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public EditModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buses Buses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buses =  await _context.Buses.FirstOrDefaultAsync(m => m.IdBus == id);
            if (buses == null)
            {
                return NotFound();
            }
            Buses = buses;
            ViewData["IdLinea"] = new SelectList(_context.Lineas, "IdLinea", "Nombre");
            ViewData["IdParqueo"] = new SelectList(_context.Set<Parqueos>(), "IdParqueo", "Ubicacion");
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

            _context.Attach(Buses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusesExists(Buses.IdBus))
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

        private bool BusesExists(int id)
        {
            return _context.Buses.Any(e => e.IdBus == id);
        }
    }
}
