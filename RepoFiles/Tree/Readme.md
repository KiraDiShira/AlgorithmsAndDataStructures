* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Tree

* [Definition](#definition)
* [Depth-first](#depth-first)
* [Breath-first](#breath-first)

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

```c#
public class Tree<T>
{
    public T Key { get; set; }
    public Tree<T> Left { get; set; }
    public Tree<T> Right { get; set; }
}
```c#


**Height**: maximum depth of subtree node and farthest leaf

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree1.PNG" />

**Size**: number of nodes

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree2.PNG" />

Often we want to visit the nodes of a tree in a particular order. For example, print the nodes of the tree.

**Depth-first**: We completely traverse one sub-tree before exploring a sibling sub-tree.

**Breadth-first**: We traverse all nodes at one level before progressing to the next level.

## Depth-first

In order traversal has a meaning only for binary tree, because every tree has maximum two child and between them I can insert the print procedure.

Depth-first search now is implemented in a recursive way, but it can also be implemented with an iterative alghoritm and a stack.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree3.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree4.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree5.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree6.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree7.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree8.PNG" />

## Breath-first

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree9.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Tree/Images/tree10.PNG" />
