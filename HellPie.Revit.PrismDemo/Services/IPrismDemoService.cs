using System;
using HellPie.Revit.PrismDemo.Services.Args;

namespace HellPie.Revit.PrismDemo.Services {
    public interface IPrismDemoService {
        event EventHandler<DocumentTitleChangedEventArgs> DocumentTitleChanged;

        string Title { get; }

        void SetDocumentTitle(string title);
    }
}
