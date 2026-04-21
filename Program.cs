namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public class Solution
        {
            public int CountComponents(int n, int[][] edges)
            {
                int reult = 0;
                int[] dsu = new int[n];
                for (int i = 0; i < n; i++)
                    dsu[i] = i;//Nodes are 0-indexed no need to add 1.

                foreach (int[] edge in edges)
                    Union(edge[0], edge[1]);

                for (int i = 0; i < n; i++)
                {
                    int unionRoot = FindUnionRoot(i);
                    //This means that thi node is the root of a component.
                    //In other word, it didn't get unioned with any other node.
                    if (i == unionRoot)
                        reult++;
                }

                return reult;
                int FindUnionRoot(int v)
                {
                    if (dsu[v] == v)
                        return v;
                    return dsu[v] = FindUnionRoot(dsu[v]);
                }
                void Union(int i, int j)
                {
                    int root1 = FindUnionRoot(i);
                    int root2 = FindUnionRoot(j);
                    if (root1 != root2)
                        dsu[root1] = root2;
                }
            }
        }
    }
}