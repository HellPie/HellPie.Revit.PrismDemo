using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autodesk.Revit.UI;
using HellPie.Revit.PrismDemo.Commands;
using HellPie.Revit.PrismDemo.Prism;
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
            string showWindowCommand = typeof(ShowWindowCommand).FullName;
            string showShellCommand = typeof(ShowShellCommand).FullName;

            new RainbowBuilder(application).Build(new Tab {
                Name = "Prism Demo",
                Panels = new [] {
                    new Panel {
                        Name = "All Commands",
                        Enabled = true,
                        Visible = true,
                        Items = new BaseItem[] {
                            new Button {
                                Assembly = assemblyLocation,
                                Class = showWindowCommand,
                                AvailabilityClass = showWindowCommand,
                                Name = showWindowCommand,
                                Text = "Show Window",
                                Description = "Shows a single window using Prism for MVVM management.",
                                Enabled = true,
                                Visible = true,
                            },
                            new Button {
                                Assembly = assemblyLocation,
                                Class = showShellCommand,
                                AvailabilityClass = showShellCommand,
                                Name = showShellCommand,
                                Text = "Show Shell",
                                Description = "Shows a window using Prism for MVVM management with custom user controls also using Prism.",
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
            //
        }
    }
}
