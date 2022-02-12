using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblDiscount : AuditableBaseEntity
    {
        #region Constructor
        public tblDiscount()
        {

        }
        #endregion

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsPercent { get; set; }

        [Required]
        public decimal DiscountValue { get; set; }

        [Required]
        public string DiscountCode { get; set; }

        [Required]
        public bool Enable { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        #region Foreign Key

        public virtual int? tblProductId { get; set; }
        public virtual tblProduct tblProduct { get; set; }

        #endregion
    }
}
