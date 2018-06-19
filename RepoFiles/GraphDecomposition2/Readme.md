- [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#table-of-contents)

# Graph Decomposition 2

- [Directed Graphs](#directed-graphs)
- [Topological Sort](#topological-sort)

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

**Linear Ordering**

We would like to order tasks to respect dependencies as below.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_1.PNG" />

Is it always possible to do this? **NO**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_2.PNG" />

A **cycle** in a graph G is a sequence of vertices v1, v2, . . . , vn so that (v1, v2),(v2, v3), . . . ,(vn−1, vn),(vn, v1) are all edges.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_3.PNG" />

Theorem. If G contains a cycle, it cannot be linearly ordered.

A directed graph G is a **Directed Acyclic Graph** (or DAG) if it has no cycles.

Theorem. Any DAG can be linearly ordered.

Which of the following graphs is a DAG?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_4.PNG" />

## Topological Sort

A **source** is a vertex with no incoming edges. A **sink** is a vertex with no outgoing edges.

How many sinks does the graph below have?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_5.PNG" />

We wanted to be able to linearly order the vertices of a graph.

Idea:

- Find sink.
- Put at end of order.
- Remove from graph.
- Repeat.

Example:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_6.PNG" />

Example ordered:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_7.PNG" />

Question: How do we know that there is a sink?

Follow path as far as possible v1 → v2 → . . . → vn. Eventually either:
- Cannot extend (found sink).
- Repeat a vertex (have a cycle)

**TopologicalSort(G)**
```
DFS(G)
sort vertices by reverse post-order
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/GraphDecomposition2/Images/gd2_8.PNG" />

```c#
public void Explore(Node<T> node)
{
    node.IsVisited = true;
    Console.WriteLine($"previsit: {node.Key}");
    IEnumerable<Node<T>> neighbours = GetNeighbours(node);
    foreach (Node<T> neighbour in neighbours)
    {
        if (!neighbour.IsVisited)
        {
            Explore(neighbour);
            
        }
    }
    Console.WriteLine($"postvisit: {node.Key}");
}
```
```
previsit: A
previsit: B
previsit: C
previsit: D
postvisit: D
postvisit: C
postvisit: B
previsit: E
postvisit: E
postvisit: A
```
