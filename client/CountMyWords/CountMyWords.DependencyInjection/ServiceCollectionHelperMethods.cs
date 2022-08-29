using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CountMyWords.DependencyInjection
{
    internal static class ServiceCollectionHelperMethods
    {
        // Registers dependencies in the DI container automatically
        // This is just a simple case how automatic registration could be done
        // and it supports only interfaces that are implemented directly by a single class
        // In practice, automatic registration's logic would be much more complex (it'd support decorators, multi inheritance, ...)
        internal static void RegisterInterfaceImplementations(this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            Type type,
            ServiceLifetime lifetime)
        {
            var inheritedInterfaces = assemblies.SelectMany(e => e.GetInterfacesThatInherit(type));
            var concreteImplementations = assemblies.SelectMany(e => e.GetConcreteImplementations()).ToList();

            foreach (var interf in inheritedInterfaces)
            {
                var implementation = concreteImplementations.FirstOrDefault(e => e.IsConcreteImplementationOfInterface(interf));

                if (implementation is not null)
                {
                    switch (lifetime)
                    {
                        case ServiceLifetime.Scoped:
                            services.AddScoped(interf, implementation);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(interf, implementation);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(interf, implementation);
                            break;
                    }
                }
            }
        }

        private static IEnumerable<Type> GetInterfacesThatInherit(this Assembly assembly, Type type)
        {
            return assembly.GetTypes()
                .Where(e => e.IsInterface && e.IsAssignableTo(type) && e != type);
        }

        private static IEnumerable<Type> GetConcreteImplementations(this Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(e => e.IsConcreteClass());
        }

        private static bool IsConcreteImplementationOfInterface(this Type type, Type interfaceType)
        {
            return type.IsConcreteClass() && type.ImplementsInterface(interfaceType);
        }

        private static bool IsConcreteClass(this Type type)
        {
            return type.IsClass && !type.IsAbstract;
        }

        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(e => e == interfaceType);
        }
    }
}