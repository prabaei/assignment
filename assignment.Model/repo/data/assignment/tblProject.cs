namespace assignment.Model.repo.data.assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProject")]
    public partial class tblProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProject()
        {
            tblProjectStaffs = new HashSet<tblProjectStaff>();
        }

        [Key]
        public int projectId { get; set; }

        [Required]
        [StringLength(80)]
        public string projectTitle { get; set; }

        public int assignee { get; set; }

        public int projectStatus { get; set; }

        public decimal progress { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime modifiedOn { get; set; }

        public bool? active { get; set; }

        public virtual tblEmployeeMaster tblEmployeeMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProjectStaff> tblProjectStaffs { get; set; }
    }
}
