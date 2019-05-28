using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Models
{
    public class ComplexSetting
    {
        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public ComplexSetting(IConfigurationSection configurationSection)
        {
            this.Value1 = configurationSection.GetValue<string>(nameof(Value1));
            this.Value2 = configurationSection.GetValue<string>(nameof(Value2));
        }
    }
}
