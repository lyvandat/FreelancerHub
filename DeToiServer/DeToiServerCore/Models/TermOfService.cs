using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToiServerCore.Models
{
    public class ContentBaseModel : ModelBase
    {
        public string Content { get; set; } = string.Empty;
        public string Tilte { get; set; } = string.Empty;
        public DateOnly PublishDate { get; set; }
    }

    public class TermOfService : ContentBaseModel
    {
        public string Url { get; set; } = string.Empty;
    }

    public class BlogPost : ContentBaseModel
    {
    }

    public class FrequentlyAskedQuestion : ContentBaseModel
    {
    }
}
