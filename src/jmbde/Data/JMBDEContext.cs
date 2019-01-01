/**************************************************************************
**
** Copyright (c) 2016-2018 Jürgen Mülbert. All rights reserved.
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


using Microsoft.EntityFrameworkCore;

namespace jmbde.Data
{
    public class JMBDEContext : DbContext {
        public virtual DbSet<jmbde.Data.Models.ChipCard> ChipCard { get; set; }
        public virtual DbSet<jmbde.Data.Models.ChipCardDoor> ChipCardDoor { get; set; }
        public virtual DbSet<jmbde.Data.Models.ChipCardProfile> ChipCardProfile {get; set;}
        public virtual DbSet<jmbde.Data.Models.CityName> CityName { get; set; }
        public virtual DbSet<jmbde.Data.Models.Company> Company { get; set; }
        public virtual DbSet<jmbde.Data.Models.Computer> Computer { get; set; }
        public virtual DbSet<jmbde.Data.Models.Department> Department { get; set; }
        public virtual DbSet<jmbde.Data.Models.DeviceName> DeviceName { get; set; }
        public virtual DbSet<jmbde.Data.Models.DeviceType> DeviceType { get; set; }
        public virtual DbSet<jmbde.Data.Models.Document> Document { get; set; }
        public virtual DbSet<jmbde.Data.Models.Employee> Employee { get; set; }
        public virtual DbSet<jmbde.Data.Models.Fax> Fax { get; set; }
        public virtual DbSet<jmbde.Data.Models.Function> Function { get; set; }
        public virtual DbSet<jmbde.Data.Models.Inventory> Inventory { get; set; }
        public virtual DbSet<jmbde.Data.Models.Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<jmbde.Data.Models.Mobile> Mobile { get; set; }
        public virtual DbSet<jmbde.Data.Models.Phone> Phone { get; set; }
        public virtual DbSet<jmbde.Data.Models.Place> Place { get; set; }
        public virtual DbSet<jmbde.Data.Models.Printer> Printer { get; set; }
        public virtual DbSet<jmbde.Data.Models.Processor> Processor { get; set; }
        public virtual DbSet<jmbde.Data.Models.Software> Software { get; set; }
        public virtual DbSet<jmbde.Data.Models.SystemAccount> SystemAccount { get; set; }

        public virtual DbSet<jmbde.Data.Models.SystemData> SystemData {get ; set; }
        public virtual DbSet<jmbde.Data.Models.JobTitle> JobTitle { get; set; }
        public virtual DbSet<jmbde.Data.Models.ZipCode> ZipCode { get; set;}
       
        public JMBDEContext(DbContextOptions<JMBDEContext> options) : base(options)
        {
        }
    }
}
