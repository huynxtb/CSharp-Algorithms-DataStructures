# Topological Sort

## Introduction
Topological Sort is a graph algorithm that produces a linear ordering of vertices in a Directed Acyclic Graph (DAG) such that for every directed edge from vertex u to vertex v, vertex u appears before vertex v in the ordering. It is primarily used in scenarios such as task scheduling, resolving symbol dependencies in compilers, and organizing prerequisite structures.

## Usage
The provided class `TopologicalSort` allows creating a directed graph using adjacency lists and performing a topological sort using a Depth-First Search (DFS) approach. The class supports dynamic graph sizes and edge additions.

// Create a graph with 6 vertices (numbered 0 to 5)
var graph = new TopologicalSort(6);

// Add directed edges
graph.AddEdge(5, 2);
graph.AddEdge(5, 0);
graph.AddEdge(4, 0);
graph.AddEdge(4, 1);
graph.AddEdge(2, 3);
graph.AddEdge(3, 1);

// Get the topological order
List<int> topoOrder = graph.GetTopologicalOrder();

// Output the order
foreach (var vertex in topoOrder)
{
    Console.WriteLine(vertex);
}

## Detailed Explanation
- **Graph Representation:** The graph is represented internally by an adjacency list, where each vertex has a list of its directed neighbors.
- **Adding Edges:** The `AddEdge` method appends an edge from vertex `u` to vertex `v`.
- **Topological Sorting:**
  - The sorting is done using a DFS-based approach.
  - We maintain two boolean arrays: `visited` to track which nodes have been traversed, and `recursionStack` to track nodes currently in the recursion call stack.
  - For each unvisited vertex, we recursively visit all its neighbors.
  - If we encounter a node that is already on the recursion stack, it indicates a cycle, and the algorithm throws an exception as topological sorting is not defined for cyclic graphs.
  - After visiting all descendants of a vertex, we push it onto a stack.
  - Finally, the stack is popped to get the vertices in topological order.

## Complexity Analysis
- **Time Complexity:** O(V + E), where V is the number of vertices and E is the number of edges. This arises because every vertex and edge is processed once in the DFS.
- **Space Complexity:** O(V + E) for storing the graph's adjacency list, plus O(V) for the recursion stack and auxiliary arrays used in DFS, resulting overall in O(V + E).

This implementation is clean, reusable, and efficiently detects cycles while producing a valid topological order or throwing an exception if none exists.