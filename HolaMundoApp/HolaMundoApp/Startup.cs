﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using HolaMundoApp.Data.API;
using HolaMundoApp.Helpers.HttpMessageHandlers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;
using System;
using System.Linq;
using Xamarin.Forms.Internals;


namespace HolaMundoApp
{
    public static class Startup
    {
        private const string INTERFACE_PREFIX = "I";
        private const string SERVICES_NAMESPACE = "HolaMundoApp.Services";
        //private const string SINGLE_INSTANCE_SERVICES_NAMESPACE = "ExampleApp.Services.SingleInstance";
        private const string VIEW_MODELS_NAMESPACE = "HolaMundoApp.ViewModels";

        private static IContainer _container;

        static Startup()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            serviceCollection.AddTransient<BaseAddressHandler>();

            // APIs
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));

            serviceCollection.AddRefitClient<IClientApi>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(Settings.ApiBaseUri))
                .AddHttpMessageHandler<BaseAddressHandler>();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<AppShell>();

            // Single Instance Services
            //containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
            //    .Where(type => type.Namespace != null && type.Namespace == SINGLE_INSTANCE_SERVICES_NAMESPACE)
            //    .As(type => type.GetInterfaces().FirstOrDefault(iface => iface.Name == INTERFACE_PREFIX + type.Name)).SingleInstance();

            // Services
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(type => type.Namespace != null && type.Namespace == SERVICES_NAMESPACE)
                .As(type => type.GetInterfaces().FirstOrDefault(iface => iface.Name == INTERFACE_PREFIX + type.Name));

            // View Models
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(type => type.Namespace != null && type.Namespace == VIEW_MODELS_NAMESPACE);

            _container = containerBuilder.Build();
            DependencyResolver.ResolveUsing(type => _container.IsRegistered(type) ? _container.Resolve(type) : null);
        }

        /// <summary>
        /// Initialize the IOC container for Autofac
        /// An empty Initialize method executes the static constructor once
        /// </summary>
        public static void Initialize() { }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>() => _container.Resolve<T>();
    }
}
