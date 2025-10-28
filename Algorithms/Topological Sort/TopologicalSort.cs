using System;
using System.Collections.Generic;

public class TopologicalSort
{
    private readonly int _vertexCount;
    private readonly List<int>[] _adjacencyList;

    /// <summary>
    /// Initializes a new instance of the TopologicalSort class with the specified number of vertices.
    /// </summary>
    /// <param name="vertexCount">Number of vertices in the graph.</param>
    public TopologicalSort(int vertexCount)
    {
        if (vertexCount <= 0)
            throw new ArgumentException("The number of vertices must be positive.", nameof(vertexCount));

        _vertexCount = vertexCount;
        _adjacencyList = new List<int>[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            _adjacencyList[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds a directed edge from vertex u to vertex v.
    /// </summary>
    /// <param name="u">The source vertex.</param>
    /// <param name="v">The destination vertex.</param>
    public void AddEdge(int u, int v)
    {
        ValidateVertex(u);
        ValidateVertex(v);
        _adjacencyList[u].Add(v);
    }

    /// <summary>
    /// Returns a topological ordering of vertices in the DAG.
    /// Throws InvalidOperationException if the graph contains a cycle.
    /// </summary>
    /// <returns>List of vertices in topologically sorted order.</returns>
    public List<int> GetTopologicalOrder()
    {
        var visited = new bool[_vertexCount];
        var recursionStack = new bool[_vertexCount];
        var topoOrderStack = new Stack<int>();

        for (int vertex = 0; vertex < _vertexCount; vertex++)
        {
            if (!visited[vertex])
            {
                DFS(vertex, visited, recursionStack, topoOrderStack);
            }
        }

        var topoOrder = new List<int>(topoOrderStack.Count);
        while (topoOrderStack.Count > 0)
        {
            topoOrder.Add(topoOrderStack.Pop());
        }

        return topoOrder;
    }

    private void DFS(int vertex, bool[] visited, bool[] recursionStack, Stack<int> topoOrderStack)
    {
        visited[vertex] = true;
        recursionStack[vertex] = true;

        foreach (var neighbor in _adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited, recursionStack, topoOrderStack);
            }
            else if (recursionStack[neighbor])
            {
                throw new InvalidOperationException("Graph contains a cycle: topological sorting is not possible.");
            }
        }

        recursionStack[vertex] = false;
        topoOrderStack.Push(vertex);
    }

    private void ValidateVertex(int vertex)
    {
        if (vertex < 0 || vertex >= _vertexCount)
            throw new ArgumentOutOfRangeException(nameof(vertex), "Vertex index is out of valid range.");
    }
}