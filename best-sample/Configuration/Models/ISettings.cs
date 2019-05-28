using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Models
{
    public interface ISettings
    {
        ComplexSetting Complex { get; set; }
    }
}
