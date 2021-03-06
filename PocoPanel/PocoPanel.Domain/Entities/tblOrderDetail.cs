using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblOrderDetail : AuditableBaseEntity
    {
        #region Constructor
        public tblOrderDetail()
        {

        }
        #endregion

        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public decimal TotallPrice { get; set; }

        [Required]
        public string SocialUserName { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int? ProviderOrderId { get; set; }

        #region Foreign Key
        [Required]
        public virtual int tblProductId { get; set; }
        public virtual tblProduct tblProduct { get; set; }

        public virtual int? tblOrderId { get; set; }
        public virtual tblOrder tblOrder { get; set; }

        [Required]
        public virtual int tblStatusId { get; set; }
        public virtual tblStatus tblStatus { get; set; }

        #endregion
    }
}
