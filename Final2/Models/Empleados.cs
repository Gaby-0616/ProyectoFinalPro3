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
    
    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.Licencias = new HashSet<Licencias>();
            this.Permisos = new HashSet<Permisos>();
            this.Vacaciones = new HashSet<Vacaciones>();
            this.SalidaEmpleado = new HashSet<SalidaEmpleado>();
        }
    
        public int IdEmpleado { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> Departamento { get; set; }
        public Nullable<int> Cargo { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<double> Salario { get; set; }
        public string Estatus { get; set; }
    
        public virtual Cargos Cargos { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licencias> Licencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permisos> Permisos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacaciones> Vacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalidaEmpleado> SalidaEmpleado { get; set; }
    }
}