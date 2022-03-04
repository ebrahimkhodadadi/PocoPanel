using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Domain.Common;

namespace PocoPanel.Domain.Entities
{
    public class tblProvider : AuditableBaseEntity
    {
        public string Url { get; set; }
        public string DocumentAddress { get; set; }
        public string ProviderToken { get; set; }
        public decimal ProviderCredit { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public virtual ICollection<tblProduct> tblProduct { get; set; }
    }
}