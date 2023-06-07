using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    internal class PNode<T>:Node<T>
    {
        public int priority { get; set; }
        public PNode<T> Next { get; set; }
        public PNode(T value, int priority)
        {
            this.priority = priority;
            this.Next = null;
            this.Value = value;
            
        }
        public PNode()
        {
            this.priority = -1;
            this.Next = null;
       
        }
    }
}
