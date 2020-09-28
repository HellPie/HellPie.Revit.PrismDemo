using System;
using System.Diagnostics.CodeAnalysis;
using Autodesk.Revit.UI;
using HellPie.Revit.PrismDemo.Prism;
using Prism.Ioc;

namespace HellPie.Revit.PrismDemo {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class App : PrismExternalApplication {
        /// <inheritdoc />
        public override Result OnStartup(UIControlledApplication application) {
            Result result = base.OnStartup(application);
            if(result != Result.Succeeded) {
                return result;
            }

            return Result.Succeeded;
        }

        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            // Not implemented yet
        }
    }
}
