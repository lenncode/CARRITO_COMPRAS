//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_VENTAS01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTA()
        {
            this.ListaVenta = new HashSet<ListaVenta>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> DIA_VENTA { get; set; }
        public Nullable<double> SUBTOTAL { get; set; }
        public Nullable<double> IVA { get; set; }
        public Nullable<double> TOTAL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
    }
}
