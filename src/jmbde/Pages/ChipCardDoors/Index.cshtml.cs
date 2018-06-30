using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardDoors
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<ChipCardDoor> ChipCardDoor { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var doors = from d in _context.ChipCardDoor
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                doors = doors.Where(cd => cd.Number.Contains(searchString));
            }
            ChipCardDoor = await doors.ToListAsync();
        }
    }
}
