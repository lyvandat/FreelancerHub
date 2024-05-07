using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models.Reports
{
    public class ReportImage : ModelBase
    {
        public required string Image { get; set; }
        public Guid ReportId { get; set; }
        public Report? Report { get; set; }
    }
}
