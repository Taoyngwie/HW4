using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;
    private int numNodes;

    public Graph(int numNodes)
    {
        this.numNodes = numNodes;
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }

        adjacencyList[source].Add(destination);
    }

    public bool IsReachable(int source, int destination)
    {
        bool[] visited = new bool[numNodes];
        DFS(source, visited);

        return visited[destination];
    }

    private void DFS(int node, bool[] visited)
    {
        visited[node] = true;

        if (!adjacencyList.ContainsKey(node)) return;

        foreach (int neighbor in adjacencyList[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of nodes in the graph: ");
        int numNodes = int.Parse(Console.ReadLine());

        Graph graph = new Graph(numNodes);

        Console.WriteLine("Enter edges as pairs of nodes (0 <= i,j < n) (negative or out of range values to stop):");
        while (true)
        {
            Console.Write("Source: ");
            int source = int.Parse(Console.ReadLine());
            if (source < 0 || source >= numNodes) break;

            Console.Write("Destination: ");
            int destination = int.Parse(Console.ReadLine());
            if (destination < 0 || destination >= numNodes) break;

            graph.AddEdge(source, destination);
        }

        Console.WriteLine("Enter pairs of nodes to check reachability (0 <= i,j < n):");
        while (true)
        {
            Console.Write("Source: ");
            int source = int.Parse(Console.ReadLine());
            if (source < 0 || source >= numNodes) break;

            Console.Write("Destination: ");
            int destination = int.Parse(Console.ReadLine());
            if (destination < 0 || destination >= numNodes) break;

            if (graph.IsReachable(source, destination))
            {
                Console.WriteLine("Reachable");
                break;
            }
            else
            {
                Console.WriteLine("Unreachable");
                break;
            }
        }
    }
}
