* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# AVL Trees

* [Introduction](#introduction)

## Introduction

AVL trees are a specific way of maintaining balance in your binary search tree. We want to maintain balance and we need a way to measure balance.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/AVLTrees/Images/avl1.PNG" />

- Height is 1 if the node is a leaf
- Height = 1 + max(node.Left.Height, node.Right.height) otherwise

In order to make use of this height we are going to add a new field to our nodes:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/AVLTrees/Images/avl2.PNG" />

And note that we are going to have to do some work to insure that this height field is actually kept up to date. 

For the balance we want size of subtrees roughly the same.

**AVL Property**: AVL trees maintain the following property: For all nodes N,

```
|N.Left.Height − N.Right.Height| ≤ 1
```

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/AVLTrees/Images/avl3.PNG" />

We claim that this ensures balance.



We need to show that AVL property implies Height = O(log(n)).

https://people.csail.mit.edu/alinush/files/alin-tomescu-cv.pdf

https://www.dei.unipd.it/~depoli/fi2ae/slides_pw/lucidi-07/liste_alberi/T6_AVLTree-06.pdf
