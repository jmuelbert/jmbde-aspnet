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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Manufacturers { /// Delete model.
    /// </summary>
    public class DeleteModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly JMuelbert.BDE.Data.ApplicationDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Manufacturers.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public DeleteModel (ILogger<DeleteModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the Manufacturer.
        /// </summary>
        /// <value>The Manufacturer.</value>
        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the ErrorMessage.
        /// </summary>
        /// <value>The ErrorMessage.</value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="saveChangesError">Save changes error.</param>
        public async Task<IActionResult> OnGetAsync (long? id, bool? saveChangesError = false) {
            _logger.LogDebug ($"Manufacturers/Delete/OnGetAsync({ id }, { saveChangesError })");
            if (id == null) {
                return NotFound ();
            }

            Manufacturer = await _context.Manufacturer
                .AsNoTracking ()
                .FirstOrDefaultAsync (m => m.ManufacturerId == id).ConfigureAwait (false);

            if (Manufacturer == null) {
                return NotFound ();
            }

            if (saveChangesError.GetValueOrDefault ()) {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page ();
        }

        /// <summary>
        /// Ons the post async.
        /// </summary>
        /// <returns>The post async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnPostAsync (long? id) {
            _logger.LogDebug ($"Manufacturerss/Delete/OnPostAsync ({ id })");

            if (id == null) {
                return NotFound ();
            }

            var manufacturer = await _context.Manufacturer
                .AsNoTracking ()
                .FirstOrDefaultAsync (m => m.ManufacturerId == id).ConfigureAwait (false);

            if (manufacturer == null) {
                return NotFound ();
            }

            try {
                _context.Manufacturer.Remove (manufacturer);
                await _context.SaveChangesAsync ().ConfigureAwait (false);
                return RedirectToPage ("./Index");
            } catch (DbUpdateException ex) {

                _logger.LogError ("Manufacturers/Delete {0}", ex.ToString ());

                return RedirectToAction ("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}
