using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new ListGraph();
            var bob = new Vertex("Bob");
            var alice = new Vertex("Alice");
            var mark = new Vertex("Mark");
            var rob = new Vertex("Rob");
            var maria = new Vertex("Maria");
            graph.AddVertex(bob);
            graph.AddVertex(alice);
            graph.AddVertex(mark);
            graph.AddVertex(rob);
            graph.AddVertex(maria);
            graph.AddEdge(bob, alice);
            graph.AddEdge(bob, rob);
            graph.AddEdge(alice, mark);
            graph.AddEdge(rob, mark);
            graph.AddEdge(alice, maria);
            graph.AddEdge(rob, maria);

            graph.RemoveEdge(alice, maria);
            graph.RemoveVertex(mark);
            foreach (var vertex in graph.GetAdjacentVertices(alice))
            {
                Console.WriteLine(vertex.Label);
            }
        }
    }
}
