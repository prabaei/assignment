namespace assignment.Model.repo.data.assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEmployeeMaster")]
    public partial class tblEmployeeMaster:api.Iemployeemaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployeeMaster()
        {
            tblProjects = new HashSet<tblProject>();
            tblProjectStaffs = new HashSet<tblProjectStaff>();
        }

        [Key]
        public int empId { get; set; }

        [Required]
        [StringLength(80)]
        public string name { get; set; }

        [Required]
        [StringLength(80)]
        public string mobile { get; set; }

        public int employeeRole { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime modifiedOn { get; set; }

        public bool? active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProjectStaff> tblProjectStaffs { get; set; }
    }
}
