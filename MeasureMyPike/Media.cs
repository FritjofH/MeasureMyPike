//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeasureMyPike
{
    using System;
    using System.Collections.Generic;
    
    public partial class Media
    {
        public int Id { get; set; }
        public string MediaType { get; set; }
    
        public virtual Catch Catch { get; set; }
        public virtual MediaData Image { get; set; }
    }
}
