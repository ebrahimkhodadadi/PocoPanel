using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.Models
{
    public class PagedResponseModel<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }

        public PagedResponseModel(T data, int pageNumber, int pageSize, int recordCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.RecordCount = recordCount;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
