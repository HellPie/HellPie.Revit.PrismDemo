using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autodesk.Revit.UI;
using HellPie.Revit.PrismDemo.Commands;
using HellPie.Revit.PrismDemo.Prism;
using HellPie.Revit.PrismDemo.Views;
using Prism.Ioc;
using Stain.Rainbow;
using Stain.Rainbow.Data;
using Stain.Rainbow.Data.Internal;
using Tab = Stain.Rainbow.Data.Tab;

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

            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string showWindowCommandClass = typeof(ShowWindowCommand).FullName;

            new RainbowBuilder(application).Build(new Tab {
                Name = "Prism Demo",
                Panels = new [] {
                    new Panel {
                        Title = "All Commands",
                        Items = new BaseItem[] {
                            new Button {
                                Assembly = assemblyLocation,
                                Class = showWindowCommandClass,
                                AvailabilityClass = showWindowCommandClass,
                                Name = showWindowCommandClass,
                                Text = "Show Window",
                                Description = "Shows a single window using Prism for MVVM management.",
                                Enabled = true,
                                Visible = true,
                            },
                        },
                    },
                },
            });

            return Result.Succeeded;
        }

        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.Register<object, SinglePrismWindow>(typeof(SinglePrismWindow).FullName);
        }
    }
}
