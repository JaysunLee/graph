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
    }
}