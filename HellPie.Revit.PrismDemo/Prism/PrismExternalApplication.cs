using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Autodesk.Revit.UI;
using CommonServiceLocator;
using DryIoc;
using Prism.DryIoc;
using Prism.DryIoc.Ioc;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;

namespace HellPie.Revit.PrismDemo.Prism {
    public abstract class PrismExternalApplication : IExternalApplication {
        internal static PrismExternalApplication Instance { get; private set; }

        private readonly IContainerExtension _containerExtension = CreateContainerExtension();
        private readonly IModuleCatalog _moduleCatalog = new ModuleCatalog();

        public IContainerProvider Container => _containerExtension;

        public PrismExternalApplication() {
            Instance = this;
        }

        /// <inheritdoc />
        public virtual Result OnStartup(UIControlledApplication application) {
            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) => Container.Resolve(type));

            _containerExtension.RegisterInstance(_containerExtension);
            _containerExtension.RegisterInstance(_moduleCatalog);

            RegisterRequiredTypes(_containerExtension);
            RegisterTypes(_containerExtension);

            _containerExtension.FinalizeExtension();

            ServiceLocator.SetLocatorProvider(() => Container.Resolve<IServiceLocator>());

            ConfigureModuleCatalog(_moduleCatalog);

            RegionAdapterMappings regionAdapterMappings = Container.Resolve<RegionAdapterMappings>();
            if(regionAdapterMappings != null) {
                regionAdapterMappings.RegisterMapping(typeof(Selector), _containerExtension.Resolve<SelectorRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ItemsControl), _containerExtension.Resolve<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ContentControl), _containerExtension.Resolve<ContentControlRegionAdapter>());
            }

            IRegionBehaviorFactory regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            if(regionBehaviorFactory != null) {
                regionBehaviorFactory.AddIfMissing(BindRegionContextToDependencyObjectBehavior.BehaviorKey, typeof(BindRegionContextToDependencyObjectBehavior));
                regionBehaviorFactory.AddIfMissing(RegionActiveAwareBehavior.BehaviorKey, typeof(RegionActiveAwareBehavior));
                regionBehaviorFactory.AddIfMissing(SyncRegionContextWithHostBehavior.BehaviorKey, typeof(SyncRegionContextWithHostBehavior));
                regionBehaviorFactory.AddIfMissing(RegionManagerRegistrationBehavior.BehaviorKey, typeof(RegionManagerRegistrationBehavior));
                regionBehaviorFactory.AddIfMissing(RegionMemberLifetimeBehavior.BehaviorKey, typeof(RegionMemberLifetimeBehavior));
                regionBehaviorFactory.AddIfMissing(ClearChildViewsRegionBehavior.BehaviorKey, typeof(ClearChildViewsRegionBehavior));
                regionBehaviorFactory.AddIfMissing(AutoPopulateRegionBehavior.BehaviorKey, typeof(AutoPopulateRegionBehavior));
                regionBehaviorFactory.AddIfMissing(IDestructibleRegionBehavior.BehaviorKey, typeof(IDestructibleRegionBehavior));
            }

            ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ActivationException));
            ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ContainerException));

            Container.Resolve<IModuleManager>()?.Run();

            return Result.Succeeded;
        }

        /// <inheritdoc />
        public virtual Result OnShutdown(UIControlledApplication application) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        protected abstract void RegisterTypes(IContainerRegistry containerRegistry);

        /// <summary>
        /// Configures the <see cref="IModuleCatalog"/> used by Prism.
        /// </summary>
        protected virtual void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) { }

        private static IContainerExtension CreateContainerExtension() {
            Rules rules = Rules.Default.WithAutoConcreteTypeResolution()
                .WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.Replace)
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments));

            return new DryIocContainerExtension(new Container(rules));
        }

        private static void RegisterRequiredTypes(IContainerRegistry registry) {
            // Base WPF Application types
            registry.RegisterSingleton<ILoggerFacade, TextLogger>();
            registry.RegisterSingleton<IDialogService, DialogService>();
            registry.RegisterSingleton<IModuleInitializer, ModuleInitializer>();
            registry.RegisterSingleton<IModuleManager, ModuleManager>();
            registry.RegisterSingleton<RegionAdapterMappings>();
            registry.RegisterSingleton<IRegionManager, RegionManager>();
            registry.RegisterSingleton<IEventAggregator, EventAggregator>();
            registry.RegisterSingleton<IRegionViewRegistry, RegionViewRegistry>();
            registry.RegisterSingleton<IRegionBehaviorFactory, RegionBehaviorFactory>();
            registry.Register<IRegionNavigationJournalEntry, RegionNavigationJournalEntry>();
            registry.Register<IRegionNavigationJournal, RegionNavigationJournal>();
            registry.Register<IRegionNavigationService, RegionNavigationService>();
            registry.Register<IDialogWindow, DialogWindow>(); //default dialog host

            // Special WPF Application types
            registry.RegisterSingleton<IRegionNavigationContentLoader, RegionNavigationContentLoader>();
            registry.RegisterSingleton<IServiceLocator, DryIocServiceLocatorAdapter>();
        }
    }
}
