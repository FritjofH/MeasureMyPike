//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeasureMyPike.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WeatherDataDO
    {
        public int Id { get; set; }
        public Nullable<double> WaterTemperature { get; set; }
        public string Weather { get; set; }
        public string MoonPosition { get; set; }
        public Nullable<double> AirTemperature { get; set; }
    
        public virtual CatchDO Catch { get; set; }
    }
}
