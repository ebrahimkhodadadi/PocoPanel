using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
