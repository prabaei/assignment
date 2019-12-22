using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Data
{
    public class moduleReg:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Data.repo.data.assignment.assignmentContext()).As<Model.repo.data.assignment.Idbcontext>().InstancePerDependency();
        }
    }
}
