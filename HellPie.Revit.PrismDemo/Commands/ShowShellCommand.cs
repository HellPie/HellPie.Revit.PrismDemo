using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HellPie.Revit.PrismDemo.Prism;
using HellPie.Revit.PrismDemo.Views;

namespace HellPie.Revit.PrismDemo.Commands {
    [Transaction(TransactionMode.ReadOnly)]
    public class ShowShellCommand : IExternalCommand, IExternalCommandAvailability {
        /// <inheritdoc />
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
            PrismUtils.CreateWindow<ShellPrismWindow>().ShowDialog();
            return Result.Succeeded;
        }

        /// <inheritdoc />
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories) {
            return true;
        }
    }
}
