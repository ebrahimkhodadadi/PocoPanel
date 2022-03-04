using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblQuality : BaseEntity
    {
        #region Constructor
        public tblQuality()
        {

        }
        #endregion

        [StringLength(20)]
        public string Name { get; set; }

        #region Foreign Key
        public virtual ICollection<tblProduct> TblProduct { get; set; }
        #endregion
    }
}
