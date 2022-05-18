using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Graphs.UnweightedGraph
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractGraph<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private uint[,] edges;

        /// <summary>
        /// 
        /// </summary>
        public List<Vertex<T>> Vertices { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public uint NumberOfVertices { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfVertices"></param>
        public AbstractGraph(uint numberOfVertices)
        {
            Vertices = new List<Vertex<T>>();
            NumberOfVertices = 0;
            edges = new uint[numberOfVertices, numberOfVertices];

            for (int i = 0; i < NumberOfVertices; i++)
            {
                for (int j = 0; j < NumberOfVertices; j++)
                {
                    edges[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex.IsValid())
            {
                Vertices.Add(vertex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startingVertex"></param>
        /// <param name="endingVertex"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddEdge(Vertex<T> startingVertex, Vertex<T> endingVertex)
        {
            if (startingVertex.IsValid() && endingVertex.IsValid())
            {
                int startingVertexIndex = Vertices.IndexOf(startingVertex);
                int endingVertexIndex = Vertices.IndexOf(endingVertex);

                if (startingVertexIndex >= 0 && endingVertexIndex >= 0)
                {
                    edges[startingVertexIndex, endingVertexIndex] = 1;
                    edges[endingVertexIndex, startingVertexIndex] = 1;
                }
                else
                {
                    throw new ArgumentException(Err.UnweightedGraph_AddEdge_ArgumentNotAvailable);
                }
            }
            else
            {
                throw new ArgumentException(Err.UnweightedGraph_AddEdge_ArgumentInvalid);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> BreadthFirstTraversal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> DepthFirstTraversal(Action<T> action)
        {
            /*
             * Pseudocode:
             * 1. DepthFirstTraversal is going to be a recursive function. That's why we will 
             *    require an argument in the function which will be the starting point.
             * 2. As soon as we enter into the method we test if the vertex is valid and if yes, proceed.
             * 3. After the validity text, we then see if there are any adjacent vertices to it. If yes, pick the first
             *    one, put it on the stack and call the DFS method recursively.
             *     
             */

            if (Vertices.Count == 0)
            {
                throw new ArgumentException(Err.UnweightedGraph_DFS_EmptyVertices);
            }

            Vertices[0].HasBeenVisited = true;
            Vertex<T> startingVertex = Vertices.FirstOrDefault();
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();

            stack.Push(startingVertex);
            startingVertex.HasBeenVisited = true;

            while (stack.Count > 0)
            {
                int nextVertexIndex = GetAdjacentVertex(startingVertex);
                Vertex<T> nextVertex = Vertices[nextVertexIndex];

                stack.Push(nextVertex)



            }






            throw new NotImplementedException();
        }

        private int GetAdjacentVertex(Vertex<T> adjacentTo)
        {
            int indexOfStartingVertex = Vertices.IndexOf(adjacentTo);
            int result = -1;

            if (indexOfStartingVertex >= 0)
            {
                for (int i = 0; i < edges.Length; i++)
                {
                    if (edges[indexOfStartingVertex, i] == 1 && Vertices[indexOfStartingVertex].HasBeenVisited == false)
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
