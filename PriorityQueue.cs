namespace Lista
{
    internal class PriorityQueue1<T> : PNode<T>
    {
        private PNode<T>? Head { get; set; }
        protected int Count { get; set; }

        public PriorityQueue1()
        {
            Head = null;
            Count = 0;
        }

        public PNode<T> GetHead()
        {
            return Head;
        }
        public int GetCount()
        {
            return Count;
        }
        public void Insert(int priority, T value)
        {
            PNode<T> node = new PNode<T>();
            node.Value = value;
            node.priority = priority;
            node.Next = null;
            if (Head != null)
            {

                if (Head.Next == null)
                {
                    if(Head.priority<=priority)
                    {
                        Head.Next = node;
                        node.Next = null;
                       
                    }
                    else
                    {
                        PNode<T> curr = Head;
                        Head = node;
                        node.Next=curr;

                    }
                  Count++;
                }
                else
                {

                    PNode<T> temp = Head;
                    if(Head.priority>priority && Head.priority!=-1)
                    {
                       
                            Head = null;
                            Head = node;
                            node.Next = temp;
              
                    }
                    PNode<T> po = new PNode<T>();
                    do
                    {

                        if (temp.Next.priority < priority) temp = temp.Next;
                        else
                        {

                            po = temp.Next;
                            break;
                        }
                    }
                    while (temp.Next != null);

                    if (Head.priority != -1 && temp.Next != null)
                    {
                        temp.Next = node;
                        node.Next = po;
                        Count++;
                    }
                    if(temp.Next ==null && temp.priority != -1)
                    {
                        temp.Next = node;
                        Count++;
                    }                    
                }

            }
            else
            {
                Head = node;
                Count++;
            }
           

        }
        public PNode<T> GetMin()
        {
            if (Head == null)
            {
                return Head;
            }
            else
            {

                if (Head.Next == null)
                {
                    PNode<T> temp = Head;
                    Head = null;
                    return temp;
                }
                else
                {
                    PNode<T> temp = Head;

                    return temp;
                }
            }

        }

        public PNode<T> RemoveMin()
        {
            
                if (Head == null)
                {
                    return null;
                }
                else
                {
                Count--;
                if (Head.Next == null)
                    {
                        PNode<T> temp = Head;
                        Head = null;
                        return temp;
                    }
                    else
                    {
                        PNode<T> temp = Head;
                        PNode<T> temp2 = Head.Next;
                        Head = temp2;
                    return temp;
                    }

            }


        }
        public void print()
        {
            PNode<T> node = Head;
            while (node.Next != null)
            {
                Console.Write("(" + node.priority + "," + node.Value + ")");
                Console.Write("->");
                node = node.Next;

            }
            Console.Write(node.priority + "," + node.Value);
            Console.WriteLine();
        }
    }
}
