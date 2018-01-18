* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Tree

* [Definition](#definition)
* [Depth-first](#depth-first)

## Definition

A **Tree** is:

* empty, or
* a node with:
  * a key, and
  * a list of child trees.
  * (optional) a parent
  
For binary tree, node contains:
* key
* left
* right
* (optional) parent

**Height**: maximum depth of subtree node and farthest leaf

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree1.PNG" />

**Size**: number of nodes

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree2.PNG" />

Often we want to visit the nodes of a tree in a particular order. For example, print the nodes of the tree.

**Depth-first**: We completely traverse one sub-tree before exploring a sibling sub-tree.

**Breadth-first**: We traverse all nodes at one level before progressing to the next level.

## Depth-first

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree3.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree4.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree5.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree6.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree7.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree8.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree9.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree10.PNG" />

What's special about arrays? Constant-time access: `O(1)`
