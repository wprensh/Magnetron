using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Commons.Bases.Request
{
    public class BasePaginationsRequest
    {
        public int NumPage { get; set; } = 1;
        public int NumRecordsPage { get; set; } = 10;
        private readonly int NumMaxRecordsPage = 50;
        public string Order { get; set; }
        public string? sort { get; set; } = null;
        public int Records
        {
            get => NumRecordsPage;
            set
            {
                NumRecordsPage = value > NumMaxRecordsPage ? NumMaxRecordsPage : value;
            }
        }
    }
}
