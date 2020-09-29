using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace HellPie.Revit.PrismDemo.Commands {
    public class ShowWindowCommand : IExternalCommand, IExternalCommandAvailability {
        /// <inheritdoc />
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
            return Result.Succeeded;
        }

        /// <inheritdoc />
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories) {
            return true;
        }
    }
}
