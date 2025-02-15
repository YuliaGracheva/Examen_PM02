using ExamApp;

namespace TestProject1
{
    public class Tests
    {
        private double[,] _adjacencyMatrix;
        private Graph _graph;
        [SetUp]
        public void Setup()
        {
            _adjacencyMatrix = new double[,]
            {
                { 0,   0.94, Double.MaxValue },
                { 0.94, 0,   1.5 },
                { Double.MaxValue, 1.5, 0 }
            };

            _graph = new Graph(3);
        }

        [Test]
        public void Test2()
        {
            int startPoint = 0; 
            int endPoint = 1; 

            double[] distances = _graph.Dijkstra(_adjacencyMatrix, startPoint, endPoint);

            double minDistance = distances[endPoint];

            double expectedDistance = 0.94;

            Assert.AreEqual(expectedDistance, minDistance, "Минимальное расстояние между точками должно быть равно 0.94.");
        }
    }
}