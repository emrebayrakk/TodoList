using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using TodoList.Business.Abstract;
using TodoList.Business.Concrete;
using TodoList.DataAccess.Abstract;
using TodoList.DataAccess.Concrete.EntityFramework;

namespace TodoList.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NoteManager>().As<INoteService>();
            builder.RegisterType<EfNoteDal>().As<INoteDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}
