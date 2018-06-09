- [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures#table-of-contents)

# Graph Basics

An (undirected) **Graph** is a collection `V` of vertices, and a collection `E` of edges each of which connects a pair of vertices.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb1.PNG" />

**Loops** connect a vertex to itself.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb2.PNG" />

**Multiple edges** between same vertices.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb3.PNG" />

If a graph has neither, it is **simple**.

## Representing Graphs

**Adjacency List**: For each vertex, a list of adjacent vertices.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb4.PNG" />

A adjacent to B, C,D
B adjacent to A
C adjacent to A,D
D adjacent to A, C

**Running times**

deg: grado di un vertice, numero di archi incidenti

* Is Edge? Θ(deg)     
* List Edge: Θ(|E|)
* List Nbrs.: Θ(deg)

## Algorithm Runtimes

Graph algorithm runtimes depend on |V| and |E|.

Which is faster, O(|V|^(3/2))) or O(|E|)?

Depends on graph! Depends on the **density**, namely how many edges you have in terms of the number of vertices.

In **dense graphs**, |E| ≈ |V|^2.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb5.PNG" />

A large fraction of pairs of vertices are connected by edges.

In **sparse graphs**, |E| ≈ |V |.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb6.PNG" />

Each vertex has only a few edges.

