using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
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

        #region Foreign Key
        public virtual tblPriceKind tblPriceKind { get; set; }

        public virtual tblProduct tblProduct { get; set; }
        #endregion
    }
}
