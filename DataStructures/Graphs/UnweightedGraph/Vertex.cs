namespace DataStructures.Graphs.UnweightedGraph
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public bool HasBeenVisited { get; set; }

        public bool IsValid()
        {
            return !(Value is null);
        }
    }
}
