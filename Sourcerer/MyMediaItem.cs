using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Gizmo.Sourcerer.ImageLibrary;
using Gizmo.Sourcerer.Structuring;

namespace Gizmo.Sourcerer
{
    /// <summary>
    /// Represents a custom media item.
    /// </summary>
    public class MyMediaItem : Node
    {
        public override string Name => "Test";

        public override Visual Thumbnail => new RubiksCube();

        public override DateTime CreationDate => DateTime.Now;

        public override DateTime ModificationDate => DateTime.Now;

        public override List<string> Tags => throw new NotImplementedException();
    }
}
