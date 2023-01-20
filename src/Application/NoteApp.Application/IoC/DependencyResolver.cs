using Autofac;
using AutoMapper;
using NoteApp.Application.AutoMapper;
using NoteApp.Application.Services;
using NoteApp.Domain.Repositories;
using NoteApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<NoteRepo>().As<INoteRepo>().InstancePerLifetimeScope();

            builder.RegisterType<NoteService>().As<INoteService>().InstancePerLifetimeScope();

            //AUTOMAPPER
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
