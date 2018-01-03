using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ReviewType
    {
        public ReviewType()
        {
            DmacceptComments = new HashSet<DmacceptComment>();
        }

        public int ReviewTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<DmacceptComment> DmacceptComments { get; set; }
    }
}
