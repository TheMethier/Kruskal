namespace Lista
{

    internal class Graph1 : Vertex
    {
        public List<Vertex> Vertices;
        public int V;
        public int n;
        public int E;
        public Graph1()
        {
            Vertices = new List<Vertex>();
            int V = 0;
            int E = 0;
        }
        public void AddNewEdge(int vertex, int neighbour, int weight)
        {
            Vertex New = new Vertex();
            Tuple<int, int> link = new Tuple<int, int>(neighbour, weight);
            New.neightbours.Add(link);
            New.val = vertex;
            Vertices.Add(New);
            Vertex Old = new Vertex();
            Tuple<int, int> link1 = new Tuple<int, int>(New.val, weight);
            Old.neightbours.Add(link1);
            Old.val = neighbour;
            Vertices.Add(Old);
            E++;
            V += 2;
        }
        public Vertex AddNewVertex(int edge)
        {
            Vertex New = new Vertex();
            New.neightbours = new List<Tuple<int, int>>();
            New.val = edge;
            Vertices.Add(New);
            E++;
            return New;
        }
        public void AddNeVertexAsNeighbourOfExisting(int vertex, Vertex old, int weight)
        {
            Vertex New = new Vertex();
            Tuple<int, int> link = new Tuple<int, int>(old.val, weight);
            Tuple<int, int> link1 = new Tuple<int, int>(vertex, weight);
            New.neightbours.Add(link);
            New.val = vertex;
            Vertices.Add(New);
            Vertices.FirstOrDefault(x => x.val == old.val).neightbours.Add(link1);
            E++;
            V++;
        }
        public Vertex GetNodeByVal(int val)
        {

            if (Vertices.Find(x => x.val == val) != null)
            {
                return Vertices.Find(x => x.val == val);
            }
            return null;

        }
        public void CreateEdge(Vertex vertex1, Vertex vertex2, int weight)
        {
            if (vertex1.val != vertex2.val)
            {
                Tuple<int, int> link1 = new Tuple<int, int>(vertex1.val, weight);
                Tuple<int, int> link2 = new Tuple<int, int>(vertex2.val, weight);
                vertex1.neightbours.Add(link2);
                vertex2.neightbours.Add(link1);
                V++;
            }
            else
            {
                Tuple<int, int> link1 = new Tuple<int, int>(vertex1.val, weight);
                vertex1.neightbours.Add(link1);
                V++;

            }
        }
        public void Kruskal()//Dorób pr
        {
            Lista<Tuple<int, int, int>> wedges = new Lista<Tuple<int, int, int>>();
            Graph1 p = new Graph1();
            int counter = 0;
            Vertices.ForEach(x => x.neightbours.ForEach(n =>
            {
               
                    wedges.InsertAtTail(new Tuple<int, int, int>(n.Item2, x.val, n.Item1));
                }
            ));

            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (wedges.GetNodeByPosition(j).Value.Item1 < wedges.GetNodeByPosition(min).Value.Item1)
                    {
                        min = j;
                    }
                }
                wedges.ReplaceNodeByNode(wedges.GetNodeByPosition(min), wedges.GetNodeByPosition(i));
            }
            
            while (wedges.GetCount() > 0 && counter < V - 1)
            {
                Tuple<int, int, int> o = wedges.GetHead().Value;
                wedges.RemoveHead();
                if ((p.GetNodeByVal(o.Item2) == null) && (p.GetNodeByVal(o.Item3) == null))
                {
                    p.AddNewVertex(o.Item2);
                    p.AddNewVertex(o.Item3);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                else if ((p.GetNodeByVal(o.Item2) != null) && (p.GetNodeByVal(o.Item3) == null) && (p.GetNodeByVal(o.Item2) != p.GetNodeByVal(o.Item3)))
                {
                    p.AddNewVertex(o.Item3);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                else if ((p.GetNodeByVal(o.Item2) == null) && (p.GetNodeByVal(o.Item3) != null))
                {
                    p.AddNewVertex(o.Item2);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                else
                {
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                counter++;

            }
            Console.WriteLine("Po:");
            p.Vertices=p.Vertices.OrderBy(x => x.val).ToList();
            foreach (var edge in p.Vertices)
            {
                Console.Write(edge.val + " ma sąsiadów: ");
                foreach (Tuple<int, int> u in edge.neightbours)
                {
                    Console.Write(u.Item1 + " z wagą: " + u.Item2 + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");
        }
        public void Kruskal1()
        {
            PriorityQueue1<Tuple<int,int>> wedges = new PriorityQueue1<Tuple<int, int>>();
            int u = 0;
            Vertices.ForEach(x => x.neightbours.ForEach(n => wedges.Insert(n.Item2,new Tuple<int, int>(n.Item1, x.val))));
            for(int y=0;y<Vertices.Count;y++)
            {
                u += Vertices[y].neightbours.Count();
            }

            Graph1 p = new Graph1();
           /*
            Console.WriteLine(u);
            Console.WriteLine(wedges.GetCount());*/
            Console.WriteLine("Po:");
            int counter = 0;
        
            while (wedges.GetCount() > 0 && counter < V - 1)
            {

                PNode<Tuple<int, int>> val = wedges.GetHead();
                Tuple<int, int,int> o = new Tuple<int, int, int>(val.priority, val.Value.Item2, val.Value.Item1);
                if ((p.GetNodeByVal(o.Item2) == null) && (p.GetNodeByVal(o.Item3) == null))
                {
                    wedges.RemoveMin();
                    wedges.RemoveMin();
                    p.AddNewVertex(o.Item2);
                    p.AddNewVertex(o.Item3);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                    
                }
                else if ((p.GetNodeByVal(o.Item2) != null) && (p.GetNodeByVal(o.Item3) == null))
                {
                    wedges.RemoveMin();

                    p.AddNewVertex(o.Item3);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                else if ((p.GetNodeByVal(o.Item2) == null) && (p.GetNodeByVal(o.Item3) != null))
                {
                    wedges.RemoveMin();

                    p.AddNewVertex(o.Item2);
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                else
                {
                    if (!(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item2, o.Item1))) && !(p.GetNodeByVal(o.Item2).neightbours.Contains(Tuple.Create(o.Item3, o.Item1))))
                        p.CreateEdge(p.GetNodeByVal(o.Item2), p.GetNodeByVal(o.Item3), o.Item1);
                }
                counter++;
            }
            foreach (var edge in p.Vertices)
            {
                Console.Write(edge.val + " ma sąsiadów: ");
                foreach (Tuple<int, int> j in edge.neightbours)
                {
                    Console.Write(j.Item1 + " z wagą: " + j.Item2 + " ");
                }
                Console.WriteLine();
            }
           
        }
    }

}



