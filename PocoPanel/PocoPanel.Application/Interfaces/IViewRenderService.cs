using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Interfaces
{
    public interface IViewRenderService
    {
        public string RenderToStringAsync(string viewName, object model);
    }
}
