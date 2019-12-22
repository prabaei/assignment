using assignment.Model.repo.data.assignment;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assignment.Model.repo.data.assignment
{
    public interface Idbcontext
    {
        DbEntityEntry Entry(Object entity);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        Int32 SaveChanges();
        Task<Int32> SaveChangesAsync();
        Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
         DbSet<tblEmployeeMaster> tblEmployeeMasters { get; set; }
         DbSet<tblProject> tblProjects { get; set; }
         DbSet<tblProjectStaff> tblProjectStaffs { get; set; }
        Database Database { get; }
    }
}
