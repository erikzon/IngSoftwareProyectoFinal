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
    public class IndexModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public IndexModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Buses> Buses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Buses = await _context.Buses
                .Include(b => b.IdLineaNavigation)
                .Include(b => b.IdParqueoNavigation).ToListAsync();
        }
    }
}
