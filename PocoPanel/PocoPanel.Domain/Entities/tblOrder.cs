using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblOrder : AuditableBaseEntity
    {
        #region Constructor
        public tblOrder()
        {

        }
        #endregion

        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public decimal TotallPrice { get; set; }

        [Required]
        public byte Status { get; set; }


        #region Foreign Key
        public int? tblPriceKindId { get; set; }
        public virtual tblPriceKind tblPriceKind { get; set; }

        public virtual int? tblDiscountId { get; set; }
        public virtual tblDiscount tblDiscount { get; set; }

        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
        #endregion

    }
}
