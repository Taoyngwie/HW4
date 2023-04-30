using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int n; // Number of nodes
        Console.Write("Number of nodes: ");
        n = int.Parse(Console.ReadLine());

        // Create a dictionary to store edges between nodes
        Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

        // Receive pairs of connected nodes
        int i, j;
        Console.WriteLine("Enter pairs of connected nodes (end by entering negative or out-of-range numbers 0-" + (n - 1) + "):");
        while (true)
        {
            Console.Write("Source node: ");
            i = int.Parse(Console.ReadLine());
            if (i < 0 || i >= n) break;

            Console.Write("Destination node: ");
            j = int.Parse(Console.ReadLine());
            if (j < 0 || j >= n) break;

            AddEdge(adjacencyList, i, j);
            AddEdge(adjacencyList, j, i);
        }

        // Calculate the minimum number of symbols needed
        bool[] used = new bool[n];
        int symbolCount = 0;
        for (i = 0; i < n; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                symbolCount++;
                for (j = i + 1; j < n; j++)
                {
                    if (!used[j] && !AreConnected(adjacencyList, i, j))
                    {
                        used[j] = true;
                    }
                }
            }
        }

        // Display the result
        Console.WriteLine("Minimum number of symbols needed: " + symbolCount);
    }

    private static void AddEdge(Dictionary<int, List<int>> adjacencyList, int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }

        adjacencyList[source].Add(destination);
    }

    // Check if nodes i and j are connected
    private static bool AreConnected(Dictionary<int, List<int>> adjacencyList, int i, int j)
    {
        if (adjacencyList.ContainsKey(i) && adjacencyList[i].Contains(j))
        {
            return true;
        }

        return false;
    }
}
