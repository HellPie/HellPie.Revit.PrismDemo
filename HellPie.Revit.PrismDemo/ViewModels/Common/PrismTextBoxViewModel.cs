using Prism.Mvvm;

namespace HellPie.Revit.PrismDemo.ViewModels.Common {
    public class PrismTextBoxViewModel : BindableBase {
        private string _text;

        public string Text {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
