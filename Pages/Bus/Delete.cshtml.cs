using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Bus
{
    public class DeleteModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public DeleteModel(proyectoIngSoftware.Data.ApplicationDbContext context)
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

            var buses = await _context.Buses.FirstOrDefaultAsync(m => m.IdBus == id);

            if (buses == null)
            {
                return NotFound();
            }
            else
            {
                Buses = buses;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buses = await _context.Buses.FindAsync(id);
            if (buses != null)
            {
                Buses = buses;
                _context.Buses.Remove(Buses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
