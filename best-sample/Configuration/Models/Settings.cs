using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Models
{
    public class Settings : ISettings
    {
        public ComplexSetting Complex { get; set; }

        public Settings(IConfiguration configuration)
        {
            this.Complex = new ComplexSetting(configuration.GetSection(nameof(Complex)));
        }
    }
}
