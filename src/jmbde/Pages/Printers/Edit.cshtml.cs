/**************************************************************************
 **
 ** Copyright (c) 2016-2019 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using System.Threading.Tasks;
using JMuelbert.BDE.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Printers {
    /// <summary>
    /// Edit model.
    /// </summary>
    public class EditModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly JMuelbert.BDE.Data.ApplicationDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Printers.EditModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public EditModel (ILogger<EditModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the Printer.
        /// </summary>
        /// <value>The Printer.</value>
        [BindProperty]
        public Printer Printer { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync (long? id) {
            _logger.LogDebug ($"Printers/Edit/OnGetAsync({ id })");
            if (id == null) {
                return NotFound ();
            }

            Printer = await _context.Printer.FindAsync (id).ConfigureAwait (false);

            if (Printer == null) {
                return NotFound ();
            }
            return Page ();
        }

        /// <summary>
        /// OnPostAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync (long? id) {
            _logger.LogDebug ($"Printers/Edit/OnPostAsync({ id })");

            if (!ModelState.IsValid) {
                return Page ();
            }

            var printerToUpdate = await _context.Printer.FindAsync (id).ConfigureAwait (false);

            if (await TryUpdateModelAsync<Printer> (
                    printerToUpdate,
                    "printer", // Preset for form value
                    p => p.Name,
                    p => p.SerialNumber,
                    p => p.ServiceTag,
                    p => p.ServiceNumber,
                    p => p.Network,
                    p => p.NetworkIpAddress,
                    p => p.Active,
                    p => p.Replace,
                    p => p.Resources,
                    p => p.Color,
                    p => p.PaperSize,
                    p => p.LastUpdate
                ).ConfigureAwait (false)) {
                await _context.SaveChangesAsync ().ConfigureAwait (false);
                return RedirectToPage ("./Index");
            }

            return Page ();
        }
    }
}
