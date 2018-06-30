using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var companies = from c in _context.Company
                    select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(com => com.Name.Contains(searchString));
            }

            Company = await companies.ToListAsync();
        }
    }
}
