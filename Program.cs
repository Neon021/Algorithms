public class Codewars
{
    public static void Main(string[] args)
    {
        string[] maze = {
            "#####",
            "#S  #",
            "# # #",
            "#   #",
            "#####"
        };

        Point start = new() { x = 1, y = 1 };
        Point end = new() { x = 3, y = 3 };

        List<Point> solution = MazeSolver.Solve(maze, "#", start, end);

        Console.WriteLine("Path:");
        foreach (Point point in solution)
        {
            Console.WriteLine($"({point.x}, {point.y})");
        }
    }

    public class Point
    {
        public int x;
        public int y;
    }

    public class MazeSolver
    {
        private static readonly int[][] dir =
        {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

        private static bool Walk(string[] maze, string wall, Point curr, Point end, bool[][] seen, List<Point> path)
        {
            if (curr.x < 0 || curr.x >= maze[0].Length ||
                curr.y < 0 || curr.y >= maze.Length)
            {
                return false;
            }

            if (maze[curr.y][curr.x].ToString() == wall)
            {
                return false;
            }

            if (curr.x == end.x && curr.y == end.y)
            {
                return true;
            }

            if (seen[curr.y][curr.x])
            {
                return false;
            }

            seen[curr.y][curr.x] = true;
            path.Add(curr);

            foreach (int[] d in dir)
            {
                int x = d[0];
                int y = d[1];
                if (Walk(maze, wall, new Point { x = curr.x + x, y = curr.y + y }, end, seen, path))
                {
                    return true;
                }
            }

            path.RemoveAt(path.Count - 1);

            return false;
        }

        public static List<Point> Solve(string[] maze, string wall, Point start, Point end)
        {
            bool[][] seen = new bool[maze.Length][];
            List<Point> path = new();

            for (int i = 0; i < maze.Length; ++i)
            {
                seen[i] = new bool[maze[0].Length];
            }

            Walk(maze, wall, start, end, seen, path);

            return path;
        }
    }

}