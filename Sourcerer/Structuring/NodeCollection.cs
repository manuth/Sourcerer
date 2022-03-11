using System.Collections.ObjectModel;

namespace Gizmo.Sourcerer.Structuring
{
    /// <summary>
    /// Represents a collection of nodes.
    /// </summary>
    public class NodeCollection : ObservableCollection<Node>
    {
        /// <summary>
        /// The container of this collection.
        /// </summary>
        private Node container;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeCollection"/> class.
        /// </summary>
        /// <param name="container">The container of this collection.</param>
        public NodeCollection(Node container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the container of this collection.
        /// </summary>
        public Node Container
        {
            get
            {
                return container;
            }
        }

        /// <inheritdoc/>
        protected override void ClearItems()
        {
            foreach (Node item in Items)
            {
                item.Parent = null;
            }

            base.ClearItems();
        }

        /// <inheritdoc/>
        protected override void InsertItem(int index, Node item)
        {
            item.Parent = Container;
            base.InsertItem(index, item);
        }

        /// <inheritdoc/>
        protected override void SetItem(int index, Node item)
        {
            Node oldItem = this[index];
            base.SetItem(index, item);

            if (!Contains(oldItem))
            {
                oldItem.Parent = null;
            }
        }

        /// <inheritdoc/>
        protected override void RemoveItem(int index)
        {
            Node oldItem = this[index];
            base.RemoveItem(index);

            if (!Contains(oldItem))
            {
                oldItem.Parent = null;
            }
        }
    }
}
