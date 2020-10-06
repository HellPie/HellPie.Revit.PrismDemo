using System;
using HellPie.Revit.PrismDemo.Services.Args;

namespace HellPie.Revit.PrismDemo.Services {
    public class PrismDemoService : IPrismDemoService {
        /// <inheritdoc />
        public event EventHandler<DocumentTitleChangedEventArgs> DocumentTitleChanged;

        /// <inheritdoc />
        public string Title { get; private set; }

        /// <inheritdoc />
        public void SetDocumentTitle(string title) {
            if(string.Equals(title, Title, StringComparison.CurrentCultureIgnoreCase)) {
                return;
            }

            string oldTitle = Title;
            Title = title;
            DocumentTitleChanged?.Invoke(this, new DocumentTitleChangedEventArgs(oldTitle, title));
        }
    }
}
