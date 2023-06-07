namespace Lista
{
    internal class Graph2
    {
        public int[,] adjacencymatrix;
        public int V;
        public int E;
        public Graph2(int[,] a, int v, int e)
        {
            this.adjacencymatrix = a;
            this.V = v;
            this.E = e;
        }
        public Graph2(int V)
        {
            this.adjacencymatrix = new int[V, V];
            this.E = 0;
            this.V = V;
        }
        public void AddNewVertex(long vertex)
        {
            adjacencymatrix[vertex, vertex] = 0;
            
        }

        public void CreateEdge(int vertex1, int vertex2, int weight)
        {
            adjacencymatrix[vertex1, vertex2] = weight;
            adjacencymatrix[vertex2, vertex1] = weight;
            E++;

        }
        public void KruskalWithList()//Napraw
        {
            Graph2 p = new Graph2(V);
            int counter = 0;
            Lista<int> wedges = new Lista<int>();
            int[,] temp= new int[V,V];
            for (int i = 0; i < V; i++) {
                for (int j = 0; j < V; j++)
                {
                    temp[i, j] = adjacencymatrix[i, j];
                }
            }
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if ((temp[i, j] > 0)&&(temp[i,j]==temp[j,i])&&i!=j)
                    {
                        wedges.InsertAtTail(temp[i, j]);
                        temp[i, j] = 0;
                        temp[j, i] = 0;
                    }
                }
            }

            int n = wedges.GetCount();
            int a = 1;
            Console.WriteLine("Po:");
            /*Console.WriteLine(E);
            */
            //Sortowanie przez wybó
            for(int i=0;i<n-1;i++)
            {
                int min = i;
                for(int j=i+1;j<n;j++)
                {
                    if(wedges.GetNodeByPosition(j).Value<wedges.GetNodeByPosition(min).Value)
                    {
                        min = j;
                    }
                }
                wedges.ReplaceNodeByNode(wedges.GetNodeByPosition(min), wedges.GetNodeByPosition(i));
            }
           
                Lista<int> ver=new Lista<int>();
            while (counter < V - 1 && wedges.GetCount() > 0)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        /*Console.WriteLine(wedges.GetCount());*/
                        if (wedges.GetCount() == 0) break;

                        int min = wedges.GetHead().Value;
                        if (counter == V - 1) break;
                        
                        if ((adjacencymatrix[i, j] > 0 && (adjacencymatrix[i, j] == adjacencymatrix[j, i]) && (i != j) && (adjacencymatrix[i, j] == min)))
                        {
                            
                                if (ver.Contains(i) && ver.Contains(j))
                                {

                                }
                                else
                                {
                                    p.CreateEdge(i, j, min);
                                }
                                wedges.RemoveHead();
                                ver.InsertAtHead(i);
                                ver.InsertAtHead(j);
                            
                          
                            counter++;

                        }

                    }
                }
            }



            for (int i = 0; i < p.V; i++)
                        {
                            for (int j = 0; j < p.V; j++)
                            {
                                Console.Write(p.adjacencymatrix[i, j]+" ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("-----------------------");
           
        
        }

        public void KruskalWithPQueue()
        {
            Graph2 p = new Graph2(V);
            int counter = 0;
            PriorityQueue1<int> wedges = new PriorityQueue1<int>();
            int[,] temp = new int[V, V];
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    temp[i, j] = adjacencymatrix[i, j];
                }
            }
            for (long i = 0; i < V; i++)
            {
                for (long j = 0; j < V; j++)
                {
                    if ((temp[i, j] > 0) && (temp[i, j] == temp[j, i]) && i != j)
                    {
                        wedges.Insert((int)adjacencymatrix[i, j], 1);
                        temp[i, j] = 0;
                        temp[j, i] = 0;
                    }
                }
            }
            Console.WriteLine("Po:");
            Lista<int> ver = new Lista<int>();
            while (counter < V-1 && wedges.GetCount()>0 )
             {
                 for (int i = 0; i < V; i++)
                 {
                     for (int j = 0; j < V; j++)
                     {
                        if (wedges.GetCount() == 0) break;
                        if (wedges.GetHead() != null)
                        {
                            int min = wedges.GetHead().priority;
                            if ((adjacencymatrix[i, j] > 0 && (adjacencymatrix[i, j] == adjacencymatrix[j, i]) && (i != j) && (adjacencymatrix[i, j] == min)))
                            {
                                if (ver.Contains(i) && ver.Contains(j))
                                {

                                }
                                else
                                {
                                    p.CreateEdge(i, j, min);
                                    adjacencymatrix[i, j] = 0;
                                    adjacencymatrix[j, i] = 0;
                                }
                                wedges.RemoveMin();
                                ver.InsertAtHead(i);
                                ver.InsertAtHead(j);
                                counter++;

                            }
                        }


                    }
                }
             }
           
            for (int i = 0; i < p.V; i++)
             {
                 for (int j = 0; j < p.V; j++)
                 {
                     Console.Write(p.adjacencymatrix[i, j]+" ");
                 }
                 Console.WriteLine();
             }
             Console.WriteLine("-----------------------");
         }
    };
}
