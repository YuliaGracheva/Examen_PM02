namespace ExamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] adjacencyMatrix = new double[10, 10];

            // Матрица смежности графа
            adjacencyMatrix = new double[,]
            {
                { 0,   0.94, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue,1.88, Double.MaxValue, Double.MaxValue, Double.MaxValue },
                { 0.94, 0,   0.66, Double.MaxValue, Double.MaxValue, Double.MaxValue, 1.2,   Double.MaxValue, Double.MaxValue, Double.MaxValue },
                { Double.MaxValue, 0.66, 0,   1.04, Double.MaxValue, 1.7,   Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue },
                { Double.MaxValue, Double.MaxValue, 1.04, 0, Double.MaxValue,  0.77,  Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue },
                { Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, 0,   1.92, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue },
                { Double.MaxValue, Double.MaxValue, 1.7,   0.77, 1.92, 0, Double.MaxValue, Double.MaxValue, Double.MaxValue,  1.52 },
                { 1.88, 1.2,   Double.MaxValue,   Double.MaxValue, Double.MaxValue, Double.MaxValue, 0,   0.53, Double.MaxValue, Double.MaxValue },
                { Double.MaxValue, Double.MaxValue,   Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, 0.53, 0,   1.54, Double.MaxValue },
                { Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, 1.54, 0,     0.86},
                { Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, 1.52, Double.MaxValue, Double.MaxValue, 0.86, 0 }
            };

            int numberOfVertices = adjacencyMatrix.GetLength(0);
            Graph graph = new Graph(numberOfVertices);

            int startPoint = GetValidInput("Введите номер начальной точки (от 1 до " + numberOfVertices + "):", numberOfVertices) - 1;
            int endPoint = GetValidInput("Введите номер конечной точки (от 1 до " + numberOfVertices + "):", numberOfVertices) - 1;

            // Проверка на корректность ввода
            if (startPoint < 0 || startPoint >= numberOfVertices || endPoint < 0 || endPoint >= numberOfVertices)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите номера от 1 до " + numberOfVertices + ".");
                return;
            }

            double[] distances = graph.Dijkstra(adjacencyMatrix, startPoint, endPoint);

            double minDistance = distances[endPoint];

            if (minDistance == double.MaxValue)
            {
                Console.WriteLine($"Нет доступного пути от точки {startPoint + 1} до точки {endPoint + 1}.");
            }
            else
            {
                Console.WriteLine($"Минимальное расстояние от точки {startPoint + 1} до точки {endPoint + 1} составляет: {minDistance:F2}");
            }
        }
        static int GetValidInput(string prompt, int numberOfVertices)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= 1 && value <= numberOfVertices)
                {
                    return value;
                }
                Console.WriteLine("Некорректный ввод! Пожалуйста введите целое число от 1 до " + numberOfVertices + ".");
            }
        }
    }
}