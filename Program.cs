using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {
        int[][] graph = new int[][]
        {
            new int[] { 0, 1, 1, 0, 0, 0 },
            new int[] { 1, 0, 0, 1, 0, 0 },
            new int[] { 1, 0, 0, 1, 1, 0 },
            new int[] { 0, 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 1, 1, 0, 0 },
            new int[] { 0, 0, 0, 1, 0, 0 }
        };

        int source = 0;
        int needle = 5;

        int[]? result = BFS(graph, source, needle);

        if (result != null)
        {
            Console.WriteLine($"Shortest path from {source} to {needle}: {string.Join(" -> ", result)}");
        }
        else
        {
            Console.WriteLine($"No path found from {source} to {needle}");
        }
    }
    public static int[]? BFS(int[][] graph, int source, int needle)
    {
        List<bool> traversedPath = new(Enumerable.Repeat(false, graph.Length));
        List<int> prev = new(Enumerable.Repeat(-1, graph.Length));

        traversedPath[source] = true;
        Queue<int> q = new();
        q.Enqueue(source);

        do
        {
            int curr = q.Dequeue();
            int[] adjs = graph[curr];

            if (curr == needle) break;

            for (int i = 0; i < adjs.Length; i++)
            {
                if (adjs[i] == 0 || traversedPath[i]) continue;

                traversedPath[i] = true;
                prev[i] = curr;
                q.Enqueue(i);
            }

        } while (q.Count > 0);

        if (prev[needle] == -1) return null;

        int current = needle;
        List<int> path = new();
        while (prev[current] != -1)
        {
            path.Add(current);
            current = prev[current];
        }

        path.Add(source);
        path.Reverse();

        return path.ToArray();
    }
}