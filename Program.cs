namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public class Solution
        {
            //You have a graph of n nodes.You are given an integer n and an array edges where edges[i] = [a, b] indicates that there is an edge between a and b in the graph.
            //Return the number of connected components in the graph.
            public int CountComponents(int n, int[][] edges)
            {
                DisjointSet dsu = new(n);
                int components = n; //We assume each node is disconnected
                foreach (int[] edge in edges)
                    components = dsu.UnionByRank(edge[0], edge[1], components);

                return components;
            }
            public class DisjointSet
            {
                private int[] _parent;
                private int[] _size;

                public DisjointSet(int n)
                {
                    _parent = new int[n];
                    _size = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        _parent[i] = i;
                        _size[i] = 1;
                    }
                }

                public int Find(int v)
                {
                    if (_parent[v] == v) return v;

                    return _parent[v] = Find(_parent[v]);
                }

                public int UnionByRank(int x, int y, int componentCount)
                {
                    int parentX = Find(x);
                    int parentY = Find(y);

                    if (parentX == parentY) return componentCount;

                    if (_size[parentX] < _size[parentY])
                    {
                        _parent[parentX] = parentY;
                        _size[parentY] += _size[parentX];
                    }
                    else
                    {
                        _parent[parentY] = parentX;
                        _size[parentX] += _size[parentY];
                    }

                    return componentCount - 1;
                }
            }
        }
    }
}