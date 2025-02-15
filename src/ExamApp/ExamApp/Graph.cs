using System.Net;

namespace ExamApp
{
    public class Graph
    {
        private int n;

        public Graph(int numberOfVertices)
        {
            n = numberOfVertices;
        }

        public double[] Dijkstra(double[,] a, int v0, int endPoint)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int[] prev = new int[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
            {
                dist[i] = Double.MaxValue;
                prev[i] = -1;
            }
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (a[v, i] != double.MaxValue && dist[i] > dist[v] + a[v, i])
                    {
                        dist[i] = dist[v] + a[v, i];
                        prev[i] = v;
                    }
                }
            }
            printPath(prev, v0, endPoint);

            return dist;
        }
        private void printPath(int[] prev, int startPoint, int endPoint)
        {
            if (prev[endPoint] == -1)
            {
                Console.WriteLine("Нет доступного пути.");
                return;
            }

            Console.Write("Путь: ");
            var path = new List<int>();

            for (int at = endPoint; at != -1; at = prev[at])
                path.Add(at);

            path.Reverse();

            foreach (var vertex in path)
                Console.Write((vertex + 1) + " "); 
            Console.WriteLine();
        }
    }
}
