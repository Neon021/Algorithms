public class Codewars
{
    public static void Main(string[] args)
    {
        // Example usage
        int vertexCount = 6;
        WeightedAdjacencyList graph = new(vertexCount);

        // Add edges to the graph
        graph.Edges[0].Add(new GraphEdge { To = 1, Weight = 1 });
        graph.Edges[1].Add(new GraphEdge { To = 2, Weight = 2 });
        graph.Edges[2].Add(new GraphEdge { To = 3, Weight = 3 });

        graph.Edges[0].Add(new GraphEdge { To = 4, Weight = 4 });
        graph.Edges[4].Add(new GraphEdge { To = 5, Weight = 5 });

        int source = 0;
        int needle = 3;

        int[]? result = DFS(graph, source, needle);

        if (result != null)
        {
            Console.WriteLine("Path found: " + string.Join(" -> ", result));
        }
        else
        {
            Console.WriteLine("Path not found.");
        }
    }
    public class GraphEdge
    {
        public int To { get; set; }
        public int Weight { get; set; }
    }

    public class WeightedAdjacencyList
    {
        public List<GraphEdge>[] Edges { get; set; }

        public WeightedAdjacencyList(int vertexCount)
        {
            Edges = new List<GraphEdge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                Edges[i] = new List<GraphEdge>();
            }
        }
    }
    private static bool Walk(WeightedAdjacencyList graph, int curr, int needle, List<bool> seen, List<int> path)
    {
        if (seen[curr]) return false;

        seen[curr] = true;

        //recurse
        //pre
        path.Add(curr);
        if (curr == needle) return true;

        //recurse
        List<GraphEdge> list = graph.Edges[curr];
        for (int i = 0; i < list.Count; i++)
        {
            GraphEdge edge = list[i];
            if (Walk(graph, edge.To, needle, seen, path)) return true;
        }

        //post
        path.RemoveAt(path.Count - 1);

        return false;
    }
    public static int[]? DFS(WeightedAdjacencyList graph, int source, int needle)
    {
        List<bool> seen = new(Enumerable.Repeat(false, graph.Edges.Length));
        List<int> path = new();

        Walk(graph, source, needle, seen, path);

        return path.Count == 0 ? null : path.ToArray();
    }
}