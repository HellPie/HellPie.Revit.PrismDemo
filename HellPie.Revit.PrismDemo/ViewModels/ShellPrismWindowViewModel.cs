using HellPie.Revit.PrismDemo.Services;
using Prism.Mvvm;

namespace HellPie.Revit.PrismDemo.ViewModels {
    public class ShellPrismWindowViewModel : BindableBase {
        private string _title;

        public string Title {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ShellPrismWindowViewModel(IPrismDemoService prismDemoService) {
            Title = prismDemoService.Title;
            prismDemoService.DocumentTitleChanged += (sender, e) => {
                Title = e.New;
            };
        }
    }
}
