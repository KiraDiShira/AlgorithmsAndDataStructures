* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# AVL Trees

* [Introduction](#introduction)

## Introduction

AVL trees are a specific way of maintaining balance in your binary search tree. We want to maintain balance and we need a way to measure balance.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/AVLTrees/Images/avl1.PNG" />

- Height is 1 if the node is a leaf
- Height = 1 + max(node.Left.Height, node.Right.height) otherwise
