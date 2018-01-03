using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Gheastandard
    {
        public Gheastandard()
        {
            GheastandardsUseds = new HashSet<GheastandardsUsed>();
        }

        public int GheastandardId { get; set; }
        public string GheastandardName { get; set; }
        public string GheastandardType { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<GheastandardsUsed> GheastandardsUseds { get; set; }
    }
}
