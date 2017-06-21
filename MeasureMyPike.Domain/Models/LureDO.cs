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
    
    public partial class LureDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LureDO()
        {
            this.Catch = new HashSet<CatchDO>();
            this.TackleBoxDO = new HashSet<TackleBoxDO>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Colour { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatchDO> Catch { get; set; }
        public virtual BrandDO Brand { get; set; }
        public virtual StatisticsDO Statistics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TackleBoxDO> TackleBoxDO { get; set; }
    }
}
