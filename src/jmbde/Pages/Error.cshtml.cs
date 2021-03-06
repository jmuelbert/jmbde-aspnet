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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages
{

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

	/// <summary>
	/// Error model.
	/// </summary>
	public class ErrorModel : PageModel
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ErrorModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		public ErrorModel(ILogger<ErrorModel> logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Gets or sets the request identifier.
		/// </summary>
		/// <value>The request identifier.</value>
		public string RequestId { get; set; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:JMBde.Pages.ErrorModel"/> show request identifier.
		/// </summary>
		/// <value><c>true</c> if show request identifier; otherwise, <c>false</c>.</value>
		public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

		/// <summary>
		/// Ons the get.
		/// </summary>
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public void OnGet()
		{
			this.logger.LogDebug("Error/OnGet");
			this.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
		}
	}
}
