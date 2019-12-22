namespace assignment.Model.repo.data.assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProjectStaff")]
    public partial class tblProjectStaff
    {
        [Key]
        [Column(Order = 0)]
        public int projectId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empId { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime modifiedOn { get; set; }

        public bool? active { get; set; }

        public virtual tblEmployeeMaster tblEmployeeMaster { get; set; }

        public virtual tblProject tblProject { get; set; }
    }
}
