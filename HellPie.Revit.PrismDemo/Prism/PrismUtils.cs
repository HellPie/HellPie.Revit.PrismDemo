using Prism.Ioc;

namespace HellPie.Revit.PrismDemo.Prism {
    public static class PrismUtils {
        public static IContainerProvider GetContainer() {
            return PrismExternalApplication.Instance.Container;
        }
    }
}
