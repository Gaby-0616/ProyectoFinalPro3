//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacacione
    {
        public int IdVacaciones { get; set; }
        public int Empleado { get; set; }
        public Nullable<System.DateTime> Desde { get; set; }
        public Nullable<System.DateTime> Hasta { get; set; }
        public string Comentario { get; set; }
    
        public virtual Empleado Empleado1 { get; set; }
    }
}
