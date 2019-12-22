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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMuelbert.BDE.Data.Models {
    /// <summary>
    /// Chip card.
    /// </summary>
    public partial class ChipCard {

        /// <summary>
        /// Gets or sets the chip card identifier.
        /// </summary>
        /// <value>The chip card identifier.</value>
        public long ChipCardId { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required]
        [StringLength (25, ErrorMessage = "ChipCardNumber cannot be longer than 25 characters.")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.ChipCard"/> is locked.
        /// </summary>
        /// <value><c>true</c> if locked; otherwise, <c>false</c>.</value>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets or sets the chip card door.
        /// </summary>
        /// <value>The chip card door.</value>
        public ICollection<ChipCardDoor> ChipCardDoor { get; set; }

        /// <summary>
        /// Gets or sets the chip card profile.
        /// </summary>
        /// <value>The chip card profile.</value>
        public ICollection<ChipCardProfile> ChipCardProfile { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public ICollection<Employee> Employee { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType (DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
