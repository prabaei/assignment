namespace assignment.Model.repo.data.assignment
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model21")
        {
        }

        public virtual DbSet<tblEmployeeMaster> tblEmployeeMasters { get; set; }
        public virtual DbSet<tblempRole> tblempRoles { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblProjectStaff> tblProjectStaffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmployeeMaster>()
                .HasMany(e => e.tblProjects)
                .WithRequired(e => e.tblEmployeeMaster)
                .HasForeignKey(e => e.assignee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEmployeeMaster>()
                .HasMany(e => e.tblProjectStaffs)
                .WithRequired(e => e.tblEmployeeMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblempRole>()
                .HasMany(e => e.tblEmployeeMasters)
                .WithRequired(e => e.tblempRole)
                .HasForeignKey(e => e.employeeRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblProject>()
                .HasMany(e => e.tblProjectStaffs)
                .WithRequired(e => e.tblProject)
                .WillCascadeOnDelete(false);
        }
    }
}
