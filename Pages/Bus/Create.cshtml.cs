using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Bus
{
    public class CreateModel : PageModel
    {
        private readonly proyectoIngSoftware.Data.ApplicationDbContext _context;

        public CreateModel(proyectoIngSoftware.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IdLinea"] = new SelectList(_context.Lineas, "IdLinea", "Nombre");
            ViewData["IdParqueo"] = new SelectList(_context.Set<Parqueos>(), "IdParqueo", "Ubicacion");
            return Page();
        }



        [BindProperty]
        public Buses Buses { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buses.Add(Buses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
