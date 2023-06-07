using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class Vertex
    {
        public List<Tuple<int, int>> neightbours;
        public int val;
        public Vertex(int val, List<Tuple<int,int>> nei)
        {
            this.val = val;
            this.neightbours = nei;
        }
        public Vertex()
        {
            this.neightbours=new List<Tuple<int,int>>(); 
        }

      }
}
