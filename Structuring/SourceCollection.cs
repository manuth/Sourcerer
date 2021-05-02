using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Gizmo.Sourcerer.Structuring
{
    /// <summary>
    /// Represents a collection of sources.
    /// </summary>
    public class SourceCollection : Node
    {
        /// <inheritdoc/>
        public override bool IsContainer
        {
            get
            {
                return true;
            }
        }

        /// <inheritdoc/>
        public override Node Parent
        {
            get
            {
                return null;
            }
        }

        public override Visual Thumbnail { get; }

        public override string Name => throw new NotImplementedException();

        public override DateTime CreationDate => throw new NotImplementedException();

        public override DateTime ModificationDate => throw new NotImplementedException();

        public override List<string> Tags => throw new NotImplementedException();
    }
}
