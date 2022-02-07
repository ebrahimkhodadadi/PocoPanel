using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblCountry : BaseEntity
    {
        #region Constructor
        public tblCountry()
        {

        }
        #endregion

        [Required]
        public string Name { get; set; }

        #region Foreign Key
        [ForeignKey("ParentID")]
        public virtual tblCountry tblCountrys { get; set; }
        public virtual int? ParentID { get; set; }
        #endregion
    }
}
