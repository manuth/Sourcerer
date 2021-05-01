using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Gizmo.Sourcerer.Explorer
{
    /// <summary>
    /// Represents an node which can be viewed in the explorer.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Gets the thumbnail of the item.
        /// </summary>
        public abstract Visual Thumbnail { get; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the human-readable name of the item.
        /// </summary>
        public virtual string DisplayName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the date of the creation of the item.
        /// </summary>
        public abstract DateTime CreationDate { get; }

        /// <summary>
        /// Gets the date of the modification of the item.
        /// </summary>
        public abstract DateTime ModificationDate { get; }

        /// <summary>
        /// Gets the tags of the item.
        /// </summary>
        public abstract List<string> Tags { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the node is visible.
        /// </summary>
        public virtual bool Visible
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this node is a container.
        /// </summary>
        public virtual bool IsContainer
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the nodes contained by this node.
        /// </summary>
        public virtual ObservableCollection<Node> ChildNodes
        {
            get
            {
                return null;
            }
        }
    }
}
