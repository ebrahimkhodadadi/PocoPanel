using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblProductPriceKind : BaseEntity
    {
        #region Constructor
        public tblProductPriceKind()
        {

        }
        #endregion

        [Required]
        public decimal Price { get; set; }

        #region Foreign Key
        public virtual int tblPriceKindId { get; set; }
        public virtual tblPriceKind tblPriceKind { get; set; }

        public virtual int tblProductId { get; set; }
        public virtual tblProduct tblProduct { get; set; }
        #endregion
    }
}
