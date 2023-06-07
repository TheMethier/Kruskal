// See https://aka.ms/new-console-template for more information

namespace Lista
{
    class TestClass
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            {
                int a = 3;
                Graph1 graph = new Graph1();
                graph.AddNewVertex(1);
                graph.AddNewVertex(3);
                graph.AddNewVertex(2);
                graph.CreateEdge(graph.GetNodeByVal(3), graph.GetNodeByVal(1), 2);
                graph.CreateEdge(graph.GetNodeByVal(3), graph.GetNodeByVal(2), 3);
                graph.CreateEdge(graph.GetNodeByVal(1), graph.GetNodeByVal(2), 1);


                Console.WriteLine("--------------------------");
                Console.WriteLine("V=" + graph.V);
                Console.WriteLine("E=" + graph.E);
                DateTime start = DateTime.Now;
                graph.Kruskal();
                Graph1 graph1 = new Graph1();
                graph1.AddNewVertex(1);
                graph1.AddNewVertex(3);
                graph1.AddNewVertex(2);
                graph1.CreateEdge(graph1.GetNodeByVal(3), graph1.GetNodeByVal(1), 2);
                graph1.CreateEdge(graph1.GetNodeByVal(3), graph1.GetNodeByVal(2), 3);
                graph1.CreateEdge(graph1.GetNodeByVal(1), graph1.GetNodeByVal(2), 1);


                DateTime stop = DateTime.Now;
                TimeSpan ts = (stop - start);
                Console.WriteLine("Kruskal z sortowaną listą sortowaniem przez wstawianie - graf na liście sąsiedztwa: " + (ts.TotalMilliseconds));
                DateTime start1 = DateTime.Now;
                graph1.Kruskal1();
                DateTime stop1 = DateTime.Now;
                TimeSpan ts1 = (stop1 - start1);
                Console.WriteLine("Kruskal z kolejką priorytetową - graf na liście sąsiedztwa: " + (ts1.TotalMilliseconds));


                int y = 3;
                Graph2 graph2 = new Graph2(y);
                graph2.CreateEdge(1, 2, 2);
                graph2.CreateEdge(0, 2, 1);
                graph2.CreateEdge(0, 1, 3);

                for (int o = 0; o < y; o++)
                {
                    for (int o1 = 0; o1 < y; o1++)
                    {
                        Console.Write(graph2.adjacencymatrix[o,o1]+" ");

                    }
                    Console.WriteLine();
                }
                    Console.WriteLine("N=" + y);
                    DateTime start2 = DateTime.Now;
                     graph2.KruskalWithList();
                    DateTime stop2 = DateTime.Now;
                    TimeSpan ts2 = (stop2 - start2);
                    Console.WriteLine("Kruskal z sortowaną listą sortowaniem przez wstawianie - graf na macierzy: " + (ts2.TotalMilliseconds));


                    DateTime start3 = DateTime.Now;
                    graph2.KruskalWithPQueue();
                    DateTime stop3 = DateTime.Now;
                    TimeSpan ts3 = (stop3 - start3);
                    Console.WriteLine("Kruskal z kolejką priorytetową - graf na macierzy: " + (ts3.TotalMilliseconds));
                }
            }
            
        }
    }

