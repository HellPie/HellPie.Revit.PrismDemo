using System;
using System.Windows;
using Prism.Ioc;
using Prism.Regions;

namespace HellPie.Revit.PrismDemo.Prism {
    public static class PrismUtils {
        public static IContainerProvider GetContainer() {
            return PrismExternalApplication.Instance.Container;
        }

        public static T CreateWindow<T>() where T : Window {
            T window = Activator.CreateInstance<T>();
            RegionManager.SetRegionManager(window, GetContainer().Resolve<IRegionManager>());
            RegionManager.UpdateRegions();
            return window;
        }
    }
}
