using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Setting
    {
        public int SettingsId { get; set; }
        public string SettingsKey { get; set; }
        public string SettingsValue { get; set; }
    }
}
