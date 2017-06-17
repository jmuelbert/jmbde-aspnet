/*
 * Copyright 2016,2017 Jürgen Mülbert
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
   will be approved by the European Commission - subsequent
   versions of the EUPL (the "Licence");
 * You may not use this work except in compliance with the Licence.
 * You may obtain a copy of the Licence at:
 *
 * https://joinup.ec.europa.eu/software/page/eupl5
 *
 * Unless required by applicable law or agreed to in
   writing, software distributed under the Licence is
   distributed on an "AS IS" basis,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
   express or implied.
 * See the Licence for the specific language governing
  permissions and limitations under the Licence.
*/

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

using jmbde.Data;
using jmbde.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The Employee-Controller
    /// </summary>
    public class EmployeeController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private jmbdesqliteContext _context;

        /// <summary>
        /// Localization
        /// </summary>
        private readonly IStringLocalizer <EmployeeController> _localizer;


        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(jmbdesqliteContext context, IStringLocalizer<EmployeeController> localizer) 
        {
            _context = context;
            _localizer = localizer;
        }

        /// <summary>
        /// GET: /<controller>/
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {   
            return View( await _context.Employee.ToListAsync() );
        }
    }
}