using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class ContentBaseModel : ModelBase
    {
        public string Content { get; set; }
    }

    public class TermOfService : ContentBaseModel
    {
        public string Tilte { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public DateOnly EffectiveDate { get; set; }
    }
}
