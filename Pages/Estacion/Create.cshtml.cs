using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyectoIngSoftware.Data;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Pages.Estacion
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
            var municipalidades = _context.Set<Municipalidades>().ToList();
            var selectList = new SelectList(municipalidades, "IdMunicipalidad", "Nombre");
            ViewData["IdMunicipalidad"] = selectList;
            return Page();
        }

        [BindProperty]
        public Estaciones Estaciones { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Estaciones.Add(Estaciones);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
