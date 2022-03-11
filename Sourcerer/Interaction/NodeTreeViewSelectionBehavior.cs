using Gizmo.Sourcerer.Structuring;

namespace Gizmo.Sourcerer.Interaction
{
    /// <summary>
    /// Provides the functionality to automatically highlight the currently selected <see cref="Node"/>.
    /// </summary>
    public class NodeTreeViewSelectionBehavior : TreeViewSelectionBehavior<Node>
    {
        /// <inheritdoc/>
        protected override bool IsInPath(Node subject, Node leaf)
        {
            if (
                subject is Node subjectNode &&
                leaf is Node leafNode)
            {
                foreach (Node subNode in subjectNode.ChildNodes)
                {
                    if (
                        subNode == leafNode ||
                        IsInPath(subNode, leafNode))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
