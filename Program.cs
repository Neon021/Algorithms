namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public List<List<int>> BuildAdjList(int[] nodes, Tuple<int, int>[] edges)
        {
            List<List<int>> graph = new();

            foreach (int node in nodes)
                graph[node] = new();

            foreach (Tuple<int, int> edge in edges)
            {
                graph[edge.Item1].Add(edge.Item2);
                graph[edge.Item2].Add(edge.Item1);
            }

            return graph;
        }

        public int[,] BuildAdjMatrix(int[] nodes, Tuple<int, int>[] edges)
        {
            Dictionary<int, int> nodeToIndex = new();
            for (int i = 0; i < nodes.Length; i++)
                nodeToIndex[nodes[i]] = i;

            int[,] graph = new int[nodes.Length, nodes.Length];

            foreach (Tuple<int, int> edge in edges)
            {
                int i = nodeToIndex[edge.Item1];
                int j = nodeToIndex[edge.Item2];

                graph[i, j] = 1;
                graph[j, i] = 1; //undirected graph
            }

            return graph;
        }
    }
}