using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PocoPanel.Domain.Entities
{
    public class tblStatus : BaseEntity
    {
        [Required]
        public string Name {get; set;}

        #region Foreign Key
        public virtual ICollection<tblOrder> tblOrder { get; set; }
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
        #endregion
    }
}