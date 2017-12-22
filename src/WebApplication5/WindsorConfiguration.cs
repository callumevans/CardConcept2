using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using System.Reflection;
using WebApplication5.Api.Interfaces;
using WebApplication5.Api.Services;
using WebApplication5.Services;

namespace WebApplication5
{
    public static class WindsorConfiguration
    {
        public static WindsorContainer BuildContainer()
        {
            var container = new WindsorContainer();

            container.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn(typeof(AbstractValidator<>))
                    .WithServiceFirstInterface()
                    .LifestyleSingleton(),

                Component.For<IRandomNumberProvider>()
                    .ImplementedBy<RandomNumberService>()
                    .LifestylePerThread(),

                Component.For<IUnixEpochProvider>()
                    .ImplementedBy<UnixEpochService>()
                    .LifestyleSingleton(),

                Component.For<UniversalDateTimeService>()
                    .LifestyleSingleton(),

                Component.For<CardBuilderService>()
                    .LifestyleSingleton(),

                Component.For<RarityService>()
                    .LifestyleSingleton(),

                Component.For<AccountService>()
                    .LifestyleSingleton()
            );

            return container;
        }
    }
}