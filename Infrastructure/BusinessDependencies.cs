using Application;
using Application.DomainEventHandlers;
using ApplicationContract;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Extensions.DependencyInjection.Extensions;
using Domain.Contract.Repositories;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Domain.Contract.Repositories.CustomerQueryRepository;
using Domain.Events;
using Framework;
using Framework.Events;
using Infrastructure.Repositories;
using Infrastructure.Repositories.CustomerCommandRepository;
using Infrastructure.Repositories.CustomerQueryRepository;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class BusinessDependencies
    {
        public static void WindsorDependencyHolder(this IWindsorContainer container)
        {
            container.Register(
            Component.For<IDomainEventHandler<CustomerCreated>>()
             .ImplementedBy<DomainEventHandler>()
             .Named(Assembly.CreateQualifiedName(
              typeof(IDomainEventHandler<CustomerCreated>).FullName, "1"
                ))
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<IDomainEventHandler<CustomerUpdated>>()
            .ImplementedBy<DomainEventHandler>()
           .Named(Assembly.CreateQualifiedName(
              typeof(IDomainEventHandler<CustomerUpdated>).FullName, "2"
                ))
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<IDomainEventHandler<CustomerDeleted>>()
            .ImplementedBy<DomainEventHandler>()
            .Named(Assembly.CreateQualifiedName(
              typeof(IDomainEventHandler<CustomerDeleted>).FullName, "3"
                ))
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<ICustomerCommandHanlder>()
            .ImplementedBy<CustomerCommandHandler>()
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<ICustomerQueryHandler>()
            .ImplementedBy<CustomerQueryHandler>()
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<ICustomerCommandRepository>()
            .ImplementedBy<CustomerCommandRepository>()
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<ICustomerQueryRepository>()
            .ImplementedBy<CustomerQueryRepository>()
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<IDispatcher>()
            .ImplementedBy<GenericDispatcher>()
            .LifeStyle.ScopedToNetServiceScope()
            );

            container.Register(
            Component.For<IUnitOfWork>()
            .ImplementedBy<UnitOfWork>()
            .LifeStyle.ScopedToNetServiceScope()
            );
        }
    }
}
