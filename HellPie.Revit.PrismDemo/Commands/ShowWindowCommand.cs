using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HellPie.Revit.PrismDemo.Prism;
using HellPie.Revit.PrismDemo.Views;
using Prism.Ioc;
using Prism.Regions;

namespace HellPie.Revit.PrismDemo.Commands {
    [Transaction(TransactionMode.ReadOnly)]
    public class ShowWindowCommand : IExternalCommand, IExternalCommandAvailability {
        /// <inheritdoc />
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
            SinglePrismWindow window = new SinglePrismWindow();
            RegionManager.SetRegionManager(window, PrismUtils.GetContainer().Resolve<IRegionManager>());
            RegionManager.UpdateRegions();
            window.ShowDialog();

            return Result.Succeeded;
        }

        /// <inheritdoc />
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories) {
            return true;
        }
    }
}
