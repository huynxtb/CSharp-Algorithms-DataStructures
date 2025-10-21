# Breadth-First Search (BFS) on Graph

## 1. Introduction
Breadth-First Search (BFS) is a fundamental graph traversal algorithm used extensively in computer science to explore nodes of a graph layer by layer. BFS is especially useful for finding the shortest path in an unweighted graph, exploring connectivity, and performing level-order traversal. This implementation focuses on an undirected, unweighted graph using adjacency lists.

## 2. Usage
The following example demonstrates how to use the `Graph` class to create a graph, add vertices and edges, and perform a BFS traversal starting from a specified vertex:

// Create a new graph instance
var graph = new Graph();

// Add edges (this also adds vertices implicitly)
graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 4);
graph.AddEdge(3, 5);

// Perform BFS starting from vertex 1
List<int> bfsOrder = graph.BFS(1);

// bfsOrder now contains the vertices in BFS traversal order: [1, 2, 3, 4, 5]

## 3. Detailed Explanation
- **Graph Representation:** The graph is represented as an adjacency list using a `Dictionary<int, List<int>>` where each key is a vertex and its value list contains neighboring vertices.

- **Adding Vertices and Edges:**
  - `AddVertex(int vertex)` ensures a vertex is added to the adjacency list if not already present.
  - `AddEdge(int v1, int v2)` adds an undirected edge by adding entries in both vertices' adjacency lists. It also adds the vertices if they don't exist.

- **BFS Traversal:**
  - The BFS method begins from a specified start vertex.
  - It uses a `Queue<int>` to maintain the order of exploration and a `HashSet<int>` to track visited nodes to avoid processing the same vertex multiple times.
  - The algorithm dequeues a vertex, records it in the result list, and enqueues all unvisited neighbors.
  - The traversal continues until the queue is empty, i.e., there are no more vertices reachable from the start vertex.

- **Handling disconnected components:** Since the BFS starts only from the given start vertex and visits all reachable vertices, any disconnected components are not visited. To traverse all vertices regardless of connectivity, one could extend the implementation to run BFS on all unvisited vertices.

## 4. Complexity Analysis
- **Time Complexity:**
  - Adding a vertex or edge is generally O(1) on average (amortized) assuming dictionary operations are O(1).
  - BFS traversal visits each vertex once and each edge once, so its time complexity is O(V + E), where V is the number of vertices reachable from the start vertex and E is the number of edges connecting those vertices.

- **Space Complexity:**
  - Adjacency list consumes O(V + E) space.
  - Additional space for BFS (visited set, queue, and result list) is O(V) for vertices visited during traversal.

This implementation provides a clean, reusable, and efficient way to manage undirected graphs and perform BFS traversals in C# within a single file and without runtime entry code.