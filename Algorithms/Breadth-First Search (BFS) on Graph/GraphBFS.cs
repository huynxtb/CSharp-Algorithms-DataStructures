using System;
using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    /// <summary>
    /// Adds a vertex to the graph.
    /// If the vertex already exists, this does nothing.
    /// </summary>
    /// <param name="vertex">The vertex identifier.</param>
    public void AddVertex(int vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<int>();
        }
    }

    /// <summary>
    /// Adds an undirected edge between two vertices.
    /// If vertices do not exist, they will be added.
    /// </summary>
    /// <param name="vertex1">The first vertex identifier.</param>
    /// <param name="vertex2">The second vertex identifier.</param>
    public void AddEdge(int vertex1, int vertex2)
    {
        AddVertex(vertex1);
        AddVertex(vertex2);

        adjacencyList[vertex1].Add(vertex2);
        adjacencyList[vertex2].Add(vertex1);
    }

    /// <summary>
    /// Performs Breadth-First Search (BFS) starting from the given vertex.
    /// Returns a list of vertices in the order they are visited.
    /// </summary>
    /// <param name="start">The starting vertex for BFS traversal.</param>
    /// <returns>List of visited vertices in BFS order.</returns>
    public List<int> BFS(int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var result = new List<int>();

        if (!adjacencyList.ContainsKey(start))
            return result;

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            result.Add(vertex);

            foreach (int neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
}