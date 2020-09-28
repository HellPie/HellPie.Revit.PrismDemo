using System.Diagnostics.CodeAnalysis;
using Autodesk.Revit.UI;

namespace HellPie.Revit.PrismDemo {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class App : IExternalApplication {
        /// <inheritdoc />
        public Result OnStartup(UIControlledApplication application) {
            return Result.Succeeded;
        }

        /// <inheritdoc />
        public Result OnShutdown(UIControlledApplication application) {
            return Result.Succeeded;
        }
    }
}
