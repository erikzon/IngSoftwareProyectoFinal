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
    public class DetailsModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public DetailsModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
