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

- A adjacent to B, C,D
- B adjacent to A
- C adjacent to A,D
- D adjacent to A, C

```c#

public class Node<T>
{
    public T Key { get; }

    public Node(T key)
    {
        Key = key;
    }

    #region Equals

    protected bool Equals(Node<T> other)
    {
        return EqualityComparer<T>.Default.Equals(Key, other.Key);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Node<T>) obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Key);
    }

    public static bool operator ==(Node<T> left, Node<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Node<T> left, Node<T> right)
    {
        return !Equals(left, right);
    }

    #endregion
    
    public override string ToString()
    {
        return $"{nameof(Key)}: {Key}";
    }
}

public class Edge<T>
{
    public Node<T> Node1 { get; }
    public Node<T> Node2 { get; }

    public Edge(Node<T> node1, Node<T> node2)
    {
        Node1 = node1;
        Node2 = node2;
    }

    public override string ToString()
    {
        return $"{nameof(Node1)}: {Node1}, {nameof(Node2)}: {Node2}";
    }
}

public class Graph<T>
{
    private readonly IDictionary<Node<T>, IList<Node<T>>> _graph;

    public Graph(IDictionary<Node<T>, IList<Node<T>>> graph)
    {
        _graph = graph;
    }

    public bool IsEdge(Edge<T> edge)
    {
        if (!_graph.ContainsKey(edge.Node1))
        {
            return false;
        }

        IEnumerable<Node<T>> connectedArcs = _graph[edge.Node1];

        foreach (Node<T> connectedArc in connectedArcs)
        {
            if (connectedArc == edge.Node2)
            {
                return true;
            }
        }

        return false;
    }

    public IList<Edge<T>> GetEdges()
    {
        IList<Edge<T>> edges = new List<Edge<T>>();

        foreach (KeyValuePair<Node<T>, IList<Node<T>>> nodes in _graph)
        {
            Node<T> node1 = nodes.Key;

            foreach (Node<T> node in nodes.Value)
            {
                Node<T> node2 = node;
                Edge<T> edge = new Edge<T>(node1, node2);
                edges.Add(edge);
            }
        }

        return edges;
    }

    public IEnumerable<Node<T>> GetNeighbours(Node<T> node)
    {
        if (!_graph.ContainsKey(node))
        {
            return new List<Node<T>>();
        }

        return _graph[node];
    }
}

```

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

## Exploring Graphs

**Reachability**

- `Input`: Graph `G` and vertex `s`
- `Output`: The collection of vertices v of G so that there is a path from `s` to `v`.

We will explore new edges in **Depth First** order. We will follow a long path forward, only backtracking when we hit a dead end.

**Explore(v)**
```
visited(v) ← true
for (v, w) ∈ E:
    if not visited(w):
        Explore(w)
```

Sometimes you want to find all vertices of G, not just those reachable from v.

**DFS(G)**
```
for all v ∈ V : mark v unvisited
for v ∈ V :
    if not visited(v):
        Explore(v)
```

- Total number of neighbors over all vertices is `O(|E|)`.
- Total runtime `O(|V | + |E|)`.

## Connected Components

The vertices of a graph `G` can be partitioned into **Connected Components** so that `v` is reachable from `w` if and only if they are in the same connected component.

How many connected components does the graph below have? 4.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb7.PNG" />

**Connected Components Problem**

`Input: Graph G
Output: The connected components of G`

**Idea**

Explore(v) finds the connected component of v. Just need to repeat to find other components. Modify DFS to do this. Modify goal to label connected components.

**Explore(v)**
```
visited(v) ← true
CCnum(v) ← cc
for (v, w) ∈ E:
    if not visited(w):
        Explore(w)
```
        
**DFS(G)**
```
for all v ∈ V mark v unvisited
cc ← 1
for v ∈ V :
    if not visited(v):
        Explore(v)
        cc ← cc + 1
```
        
Runtime still `O(|V | + |E|)`.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb8.PNG" />

## Previsit and Postvisit Orders

We're going to augment `Explore` functions in order to store additional information. 

**Explore(v)**
```
visited(v) ← true
previsit(v)
for (v, w) ∈ E:
    if not visited(w):
        explore(w)
postvisit(v)
```

Initialize clock to 1.

**previsit(v)**
```
pre(v) ← clock
clock ← clock + 1
```
**postvisit(v)**
```
post(v) ← clock
clock ← clock + 1
```

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb9.PNG" />

Previsit and Postvisit numbers tell us about the execution of DFS.

**Lemma** 
For any vertices u, v the intervals [pre(u), post(u)] and [pre(v), post(v)] are either nested or disjoint.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb10.PNG" />

Which of the following tables is not a valid set of pre- and post- orders?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Graph%20basics/Images/gb11.PNG" />
