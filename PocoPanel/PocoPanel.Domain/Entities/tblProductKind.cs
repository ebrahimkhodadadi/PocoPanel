using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblProductKind : BaseEntity
    {
        #region Constructor
        public tblProductKind()
        {

        }
        #endregion

        [Required]
        public string Name { get; set; }

        #region Foreign Key
        [ForeignKey("ParentID")]
        public virtual tblProductKind tblProductKinds { get; set; }
        public virtual int? ParentID { get; set; }

        public virtual ICollection<tblProduct> tblProducts { get; set; }
        #endregion
    }
}
