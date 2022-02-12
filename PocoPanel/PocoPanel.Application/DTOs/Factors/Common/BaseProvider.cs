using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Factors.Common
{
    public abstract class BaseProvider
    {
        public virtual string key { get; set; }
        public virtual string action { get; set; }
    }
}
