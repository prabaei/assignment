namespace assignment.Model.repo.data.assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblempRole")]
    public partial class tblempRole:api.IemployeeRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblempRole()
        {
            tblEmployeeMasters = new HashSet<tblEmployeeMaster>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string employeeRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmployeeMaster> tblEmployeeMasters { get; set; }
    }
}
