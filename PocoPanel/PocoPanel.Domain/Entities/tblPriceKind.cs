using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblPriceKind : BaseEntity
    {
        #region Constructor
        public tblPriceKind()
        {

        }
        #endregion

        [StringLength(20)]
        public string Name { get; set; }

        #region Foreign Key
        public virtual int? tblCountryId { get; set; }
        public virtual tblCountry tblCountry { get; set; }

        public virtual ICollection<tblProductPriceKind> tblProductPriceKind { get; set; }
        #endregion
    }
}
