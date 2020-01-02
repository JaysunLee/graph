using System.Collections.Generic;

namespace Graph
{
    // Undirected, unweighted graph
    class ListGraph
    {
        private Dictionary<Vertex, List<Vertex>> AdjacencyList { get; set; }

        public ListGraph()
        {
            AdjacencyList = new Dictionary<Vertex, List<Vertex>>();
        }

        public void AddVertex(Vertex vertex)
        {
            if (!AdjacencyList.ContainsKey(vertex))
            {
                AdjacencyList.Add(vertex, new List<Vertex>());
            }
        }

        public void RemoveVertex(Vertex vertex)
        {
            foreach (var adjacency in AdjacencyList.Values)
            {
                adjacency.Remove(vertex);
            }
            AdjacencyList.Remove(vertex);
        }

        public void AddEdge(Vertex vertexOne, Vertex vertexTwo)
        {
            var vertexOneAdjacents = AdjacencyList[vertexOne];
            vertexOneAdjacents.Add(vertexTwo);
            var vertexTwoAdjacents = AdjacencyList[vertexTwo];
            vertexTwoAdjacents.Add(vertexOne);
        }

        public void RemoveEdge(Vertex vertexOne, Vertex vertexTwo)
        {
            var vertexOneAdjacents = AdjacencyList[vertexOne];
            var vertexTwoAdjacents = AdjacencyList[vertexTwo];

            if (vertexOneAdjacents != null)
            {
                vertexOneAdjacents.Remove(vertexTwo);
            }
            if (vertexTwoAdjacents != null)
            {
                vertexOneAdjacents.Remove(vertexOne);
            }
        }

        public List<Vertex> GetAdjacentVertices(Vertex vertex)
        {
            return AdjacencyList[vertex];
        }

        public static HashSet<Vertex> DepthFirstTraversal(ListGraph graph, Vertex root)
        {
            HashSet<Vertex> visited = new HashSet<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                Vertex vertex = stack.Pop();
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    foreach (var adjacent in graph.GetAdjacentVertices(vertex))
                    {
                        stack.Push(adjacent);
                    }
                }
            }

            return visited;
        }

        public static HashSet<Vertex> BreadthFirstTraversal(ListGraph graph, Vertex root)
        {
            HashSet<Vertex> visited = new HashSet<Vertex>();
            Queue<Vertex> queue = new Queue<Vertex>();

            visited.Add(root);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Vertex vertex = queue.Dequeue();
                foreach (var adjacent in graph.GetAdjacentVertices(vertex))
                {
                    if (!visited.Contains(adjacent))
                    {
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }

            return visited;
        }
    }
}