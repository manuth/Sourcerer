using System.Collections.ObjectModel;
using System.Windows.Input;
using Gizmo.Sourcerer.Core;
using Gizmo.Sourcerer.Structuring;

namespace Gizmo.Sourcerer.Interaction
{
    /// <summary>
    /// Provides features for binding to a browser.
    /// </summary>
    public class BrowserViewModel : ObservableObject
    {
        /// <summary>
        /// The currently selected node.
        /// </summary>
        private Node selectedItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserViewModel"/> class.
        /// </summary>
        public BrowserViewModel()
        {
            ChangeSelection = (
                new RelayCommand<Node>(
                    (newItem) =>
                    {
                        SelectedItem = newItem;
                    }));
        }

        /// <summary>
        /// Gets or sets the currently selected node.
        /// </summary>
        public Node SelectedItem
        {
            get
            {
                return selectedItem ?? Nodes?[0];
            }

            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        /// <summary>
        /// Gets the currently opened nodes.
        /// </summary>
        public ObservableCollection<Node> Nodes { get; } = new ObservableCollection<Node>();

        /// <summary>
        /// Gets a command for changing the selection.
        /// </summary>
        public ICommand ChangeSelection { get; }
    }
}
