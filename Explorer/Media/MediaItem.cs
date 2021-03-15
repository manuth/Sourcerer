using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sourcerer.Explorer.Media
{
    /// <summary>
    /// Represents a media-explorer item.
    /// </summary>
    public abstract class MediaItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the human-readable name of the item.
        /// </summary>
        public virtual string DisplayName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets or sets the thumbnail of the item.
        /// </summary>
        public abstract Visual Thumbnail { get; }

        /// <summary>
        /// Gets or sets the date of the creation of the item.
        /// </summary>
        public abstract DateTime CreationDate { get; }

        /// <summary>
        /// Gets or sets the date of the modification of the item.
        /// </summary>
        public abstract DateTime ModificationDate { get; }
    }
}
