using Autofac;
using FullTimeForceTest.Api.Application.Commands.CreateEmployee;
using FullTimeForceTest.Api.Application.Commands.CreateStudentNote;
using FullTimeForceTest.Api.Application.Commands.CreateWordPalindroma;
using FullTimeForceTest.Api.Application.Queries;
using FullTimeForceTest.Api.Infrastructure.Repository;
using FullTimeForceTest.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Command

            builder.RegisterAssemblyTypes(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateStudentCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateWordPalindromaCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion


            #region Queries
            builder.RegisterType<EmployeeQueries>()
             .As<IEmployeeQueries>()
             .InstancePerLifetimeScope();

            builder.RegisterType<StudentQueries>()
             .As<IStudentQueries>()
             .InstancePerLifetimeScope();

            builder.RegisterType<WordQueries>()
             .As<IWordQueries>()
             .InstancePerLifetimeScope();
            
            #endregion


            #region Repository

            builder.RegisterType<ApplicationRepository>()
             .As<IApplicationRepository>()
             .InstancePerLifetimeScope();



            #endregion




        }
    }
}
