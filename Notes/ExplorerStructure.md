# Explorer Structure
This document holds information on how the data visible in the explorer is to be structured.

## Node
A node represents an item which can be displayed in the explorer.

Nodes themselves can have a set of sub-nodes. Nodes which are allowed to have a set of sub-nodes are called "containers". Containers might be presented to the user as "Album"s, "Directories" or other metadata.

### Properties
  - Thumbnail
  - Name
  - DisplayName
  - CreationDate
  - ModificationDate
  - Tags
  - Visible
  - IsContainer
  - SubNodes/Children/ChildNodes/Items/
