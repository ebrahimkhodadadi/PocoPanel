﻿using PocoPanel.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Domain.Entities
{
    public class tblProduct : AuditableBaseEntity
    {
        #region Constructor
        public tblProduct()
        {

        }
        #endregion

        public string Name { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double Decending { get; set; }

        [Required]
        public int Quantity { get; set; }

        #region Foreign Key
        [Required]
        public virtual tblProductKind tblProductKind { get; set; }

        public virtual ICollection<tblProductPriceKind> tblProductPriceKind { get; set; }
        #endregion
    }
}