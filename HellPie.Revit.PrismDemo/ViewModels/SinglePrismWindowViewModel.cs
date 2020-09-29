using Prism.Commands;
using Prism.Mvvm;

namespace HellPie.Revit.PrismDemo.ViewModels {
    public class SinglePrismWindowViewModel : BindableBase {
        private string _helloMessage = "Hello, World!";
        private int _counter;

        public string HelloMessage {
            get => _helloMessage;
            set => SetProperty(ref _helloMessage, value);
        }

        public int Counter {
            get => _counter;
            set => SetProperty(ref _counter, value);
        }

        public DelegateCommand IncrementCounter { get; }
        public DelegateCommand DecrementCounter { get; }

        public SinglePrismWindowViewModel() {
            IncrementCounter = new DelegateCommand(IncrementCounterImpl);
            DecrementCounter = new DelegateCommand(DecrementCounterImpl);
        }

        private void IncrementCounterImpl() {
            Counter++;
        }

        private void DecrementCounterImpl() {
            Counter--;
        }
    }
}
