using System;

namespace HellPie.Revit.PrismDemo.Services.Args {
    public class DocumentTitleChangedEventArgs : EventArgs {
        public string Old { get; }
        public string New { get; }

        public DocumentTitleChangedEventArgs(string oldTitle, string newTitle) {
            Old = oldTitle;
            New = newTitle;
        }
    }
}
