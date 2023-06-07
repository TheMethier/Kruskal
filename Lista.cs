namespace Lista
{
    internal class Lista<T> : Node<T>
    {
        public Lista()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private Node<T>? Head { get; set; }
        private Node<T>? Tail { get; set; }
        protected int Count { get; set; }
        public Node<T>? GetHead()
        {
            return Head;
        }
        public Node<T>? GetTail()
        {
            return Tail;
        }
        public int GetCount()
        {
            return Count;
        }
        public bool IsEmpty()
        {
            if ((Head == null) && (Tail == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Node<T> GetNodeByPosition(int id)
        {
            int i = 0;
            if (id == 0)
            {
                return Head;
            }
            else if (id == Count - 1)
            {
                return Tail;

            }
            else if (id < 0 && id > Count - 1)
            {
                return null;
            }
            else
            {
                Node<T> node = Head;
                while (node.Next != null)
                {
                    i++; if (id == i)

                    {
                        return node;//Number of steps: i+1
                        break;
                    }
                    node = node.Next;
                }
                return null;
            }
        }

        public void InsertAtHead(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
                /* Console.WriteLine("--------------------------------------------------------------------");
                 Console.WriteLine("Added " + node.Value + " at head of list.");
                 Console.WriteLine("Number of steps: "+2);
             */
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
                /*  Console.WriteLine("--------------------------------------------------------------------");
                  Console.WriteLine("Added " + node.Value + " at head of list.");
                  Console.WriteLine("Number of steps: " + 3);
              */
            }
            Count++;
        }

        public void InsertAtPosition(int index, T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;
            if (index == 1 && Head == Tail)
            {
                InsertAtTail(value);
            }
            else if ((index > 0) && (index < Count))
            {

                Node<T> temp = Head;
                int i = 0;
                while (temp.Next != null)
                {
                    i++;

                    if (i == index)
                    {
                        /*         Console.WriteLine("--------------------------------------------------------------------");
                                 Console.WriteLine("Added " + value + " at position " + index + ".");
                                 Console.WriteLine("Number of steps: " + (i + 4));
                            */
                        InsertAfter(temp, value);
                        break;
                    }
                    temp = temp.Next;

                }
            }
            else if (index == Count)
            {
                InsertAtTail(value);
            }
            else if (index == 0)
            {

                InsertAtHead(value);

            }
            else
            {/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Insertion failed: current position doesn't exist in this list.");
            */
            }
        }

        public void InsertAtTail(T value)
        {
            Node<T> node = new Node<T>();
            node.Value = value;
            if (IsEmpty())
            {
                Head = node;
                Tail = node;
                Count++;
                /*   Console.WriteLine("--------------------------------------------------------------------");
                   Console.WriteLine("Added " + node.Value + " at tail of list.");
                   Console.WriteLine("Number of steps: " + 2);
                */
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
                /*      Console.WriteLine("--------------------------------------------------------------------");
                      Console.WriteLine("Added " + node.Value+" at tail of list.");
                      Console.WriteLine("Number of steps: "  + 3);
                  */
                Count++;

            }
        }

        public void InsertBefore(Node<T> CNode, T val)
        {

            Node<T> node = new Node<T>();
            node.Value = val;
            if (CNode != null && CNode.Previous != null)
            {
                Node<T> temp = CNode.Previous;
                temp.Next = node;
                CNode.Previous = node;
                node.Previous = temp;
                node.Next = CNode;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Added " + val + " before " + CNode.Value + ".");
                Console.WriteLine("Number of steps:" + 4);*/
                Count++;
            }
            else if (CNode == Head)
            {
                InsertAtHead(val);
            }

            else
            {
                /*  Console.WriteLine("--------------------------------------------------------------------");
                  Console.WriteLine("Insertion failed: Cnode is null ");*/
            }
        }

        public void InsertAfter(Node<T> CNode, T val)
        {
            Node<T> node = new Node<T>();
            node.Value = val;
            if (CNode != null && CNode.Next != null)
            {
                Node<T> temp = CNode.Next;
                temp.Previous = node;
                CNode.Next = node;
                node.Next = temp;
                node.Previous = CNode;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Added " + val + " after " + CNode.Value+ ".");
                Console.WriteLine("Number of steps:" + 4);
  */
                Count++;
            }
            else if (CNode == Tail)
            {
                InsertAtTail(val);
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Insertion failed: CNode is null.");
                Console.WriteLine();
            }
        }

        public void ReplaceValueInCurrentNode(T val, Node<T> CNode)
        {
            if (CNode != null)
            {
                T oldval = CNode.Value;
                CNode.Value = val;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Replaced "+oldval+" by "+val+".");
                Console.WriteLine("Number of steps: " + 1);*/
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Replacement failed: CNode is null.");
            }
        }


        public void ReplaceNodeByNode(Node<T> First, Node<T> Sec)
        {
            if ((First != null) && (Sec != null))
            {
                T firstval = First.Value;
                T secval = Sec.Value;
                First.Value = secval;
                Sec.Value = firstval;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Replaced " + First.Value + " by " + Sec.Value + ".");
                Console.WriteLine("Number of steps: " + 2);*/
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Replacement failed.");

            }
        }

        public void RemoveTail()
        {
            if (IsEmpty())
            {
                print();

            }
            else if (Head == Tail)
            {
                Clear();
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
                Count--;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Removed tail of list.");
                Console.WriteLine("Number of steps: " + 2);*/
            }
        }


        public void RemoveHead()
        {
            if (IsEmpty())
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("List is empty");

            }
            else if (Head == Tail)
            {
                Clear();
            }
            else
            {
                Head.Next.Previous = null;
                Head = Head.Next;
                Count--;
                /*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Removed head of list.");
                Console.WriteLine("Number of steps: " + 2);*/
            }
        }

        public void RemoveAtPosition(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Delation failed: Out of range");

            }
            else if (index == 0)
            {
                RemoveHead();
            }
            else if (index == Count - 1) { RemoveTail(); }
            else if (Head == Tail)
            {

                Clear();
            }
            else
            {
                Node<T> CNode = GetNodeByPosition(index);
                T val = CNode.Value;
                Node<T> Left = CNode.Previous;
                Node<T> Right = CNode.Next;
                CNode = null;
                Right.Previous = Left;
                Left.Next = Right;/*
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("Removed " + val + " at position " + index + ".");
                Console.WriteLine("Number of steps: " + (index + 3));
*/
                Count--;
            }
        }
        public bool Contains(T val)
        {
            int i = 0;
            if (Head != null)
            {
                Node<T> node = Head;
                while (node.Next != null)
                {
                    i++;
                    if (Equals(node.Value, val))
                    {
                        return true;//Number of steps: i+1
                        break;
                    }
                    node = node.Next;
                }
            }

            return false;
        }
        public void Clear()
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("List is cleared");
            Console.WriteLine("Number of steps: 2");
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void print()
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("List contains:");

            if (Head != null)
            {
                if (Head == Tail)
                {
                    Console.Write(Head.Value);
                    Console.WriteLine();
                    return;
                }
                else
                {
                    Node<T> node = Head;
                    while (node.Next != null)
                    {
                        Console.Write(node.Value);
                        Console.Write("->");
                        node = node.Next;
                    }
                    Console.Write(Tail.Value);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }
      
    };
}
