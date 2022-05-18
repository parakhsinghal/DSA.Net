using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Graphs.UnweightedGraph
{
    public class Vertex<T>
    {
        public bool HasBeenVisited { get; set; }

        public bool IsValid()
        {
            return this is null;
        }
    }
}
