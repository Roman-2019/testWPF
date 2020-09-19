using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using MVVMPhone.Views;
using Prism.Autofac;
using Autofac;

namespace MVVMPhone
{
    //public class Bootstraper: UnityBootstrapper
    //{
    //    public override void Run(bool runWithDefaultConfiguration)
    //    {
    //        base.Run(runWithDefaultConfiguration);
    //    }

    //    protected override DependencyObject CreateShell()
    //    {
    //        return Container.Resolve<Shell>();
    //    }

    //    protected override void InitializeShell()
    //    {
    //        App.Current.MainWindow = (Window)Shell;
    //        App.Current.MainWindow.Show();
    //    }

    //    protected override void ConfigureModuleCatalog()
    //    {
    //        base.ConfigureModuleCatalog();

    //        //Type sampleModuleType = typeof(PhoneModule.PhoneModule);
    //        //ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo {ModuleName=sampleModuleType.Name, ModuleType=sampleModuleType.AssemblyQualifiedName });
    //    }
    //}
    public class Bootstrapper : AutofacBootstrapper
    {

        /// <summary>Creates the shell or main window of the application.</summary>
        /// <returns>The shell of the application.</returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Prism.Bootstrapper" /> will attach the default <see cref="T:Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>Initializes the shell.</summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Creates the <see cref="T:Autofac.ContainerBuilder" /> that will be used to create the default container.
        /// </summary>
        /// <returns>A new instance of <see cref="T:Autofac.ContainerBuilder" />.</returns>
        protected override ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            // регистрация зависимостей в контейнере
            // должны быть здесь...

            return builder;
        }
    }
}