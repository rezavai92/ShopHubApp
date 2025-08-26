namespace Shophub.Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Scan for assembly containing dependency injection registration classes
    /// </summary>
    internal class DependencyRegistrarScanner : IDisposable
    {
        private readonly ResolveEventHandler handler = null;

        // Lifecycle
        public DependencyRegistrarScanner()
        {
            handler = new ResolveEventHandler(Resolver);
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += handler;
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= handler;
        }

        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }

        /// <summary>
        /// Find the path of all assemblies containing registrar classes
        /// </summary>
        /// <returns>A collection of assembly paths</returns>
        public static IEnumerable<string> LocateRegistrars()
        {
            string root = Path.GetDirectoryName(
                new Uri(Assembly.GetCallingAssembly().Location).LocalPath);

            _ = Assembly.LoadFile(Path.Combine(root, "Autofac.dll"));

            var paths = Directory.GetFiles(root, "ShopHubApp.*.dll", SearchOption.TopDirectoryOnly);
            foreach (string path in paths)
            {
                if (!path.Contains("Tests."))
                {
                    var assembly = Assembly.LoadFrom(path);
                    if (assembly.ExportedTypes.Any(t =>
                        t.IsClass &&
                        !t.IsAbstract &&
                        t.BaseType.FullName != null &&
                        t.BaseType.FullName.Equals("Autofac.Module")))
                    {
                        var localpath = new Uri(assembly.Location).LocalPath;
                        //log.LogDebug("Found Autofac registration module {localpath}", localpath);
                        yield return localpath;
                    }
                }
            }
        }
    }
}
