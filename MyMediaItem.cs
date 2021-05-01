using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Gizmo.Sourcerer.Explorer.Media;
using Gizmo.Sourcerer.ImageLibrary;

namespace Gizmo.Sourcerer
{
    /// <summary>
    /// Represents a custom media item.
    /// </summary>
    public class MyMediaItem : MediaItem
    {
        public override string Name => "Test";

        public override Visual Thumbnail => new RubiksCube();

        public override DateTime CreationDate => DateTime.Now;

        public override DateTime ModificationDate => DateTime.Now;
    }
}
