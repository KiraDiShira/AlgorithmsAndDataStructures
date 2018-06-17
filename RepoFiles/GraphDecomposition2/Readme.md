- [Index]()

# Graph Decomposition 2

## Directed Graphs

A **directed graph** is a graph where each edge has a start vertex and an end vertex.

Examples:

- Streets with one-way roads.
- Links between webpages.
- Followers on social network

### Directed DFS

Can still run DFS in directed graphs.

- Only follow directed edges.
- explore(v) finds all vertices reachable from v.
- Can still compute pre- and postorderings

## Event Ordering

Linear Ordering

We would like to order tasks to respect dependencies as below.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_1.PNG" />

Is it always possible to do this? **NO**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_2.PNG" />

A cycle in a graph G is a sequence of vertices v1, v2, . . . , vn so that (v1, v2),(v2, v3), . . . ,(vn−1, vn),(vn, v1) are all edges.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_3.PNG" />

Theorem. If G contains a cycle, it cannot be linearly ordered.

A directed graph G is a **Directed Acyclic Graph** (or DAG) if it has no cycles.

Theorem. Any DAG can be linearly ordered.

Which of the following graphs is a DAG?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_4.PNG" />
