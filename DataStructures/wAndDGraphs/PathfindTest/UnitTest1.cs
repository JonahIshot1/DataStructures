using System;
using System.Collections.Generic;
using System.Drawing;
using wAndDGraphs;
namespace PathfindTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AStar_ShouldRouteAroundWall()
        {
            // Arrange
            Graph<Point> graph = new Graph<Point>();

            int width = 20;
            int height = 20;

            Vertex<Point>[,] grid = new Vertex<Point>[width, height];

            // Create vertices
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new Vertex<Point>(new Point(x, y));
                    graph.vertices.Add(grid[x, y]);
                }
            }

            // Build obstacle wall like image
            HashSet<Point> blocked = new HashSet<Point>();

            // Large rectangle obstacle
            for (int x = 4; x <= 12; x++)
            {
                for (int y = 4; y <= 12; y++)
                {
                    blocked.Add(new Point(x, y));
                }
            }

            // Vertical extension
            for (int x = 10; x <= 12; x++)
            {
                for (int y = 0; y <= 12; y++)
                {
                    blocked.Add(new Point(x, y));
                }
            }

            // Create a corridor/opening
            blocked.Remove(new Point(10, 12));
            blocked.Remove(new Point(9, 12));
            blocked.Remove(new Point(8, 12));

            // Connect neighbors (4-directional)
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Point p = new Point(x, y);

                    if (blocked.Contains(p))
                        continue;

                    for (int i = 0; i < 4; i++)
                    {
                        int nx = x + dx[i];
                        int ny = y + dy[i];

                        if (nx < 0 || ny < 0 || nx >= width || ny >= height)
                            continue;

                        Point np = new Point(nx, ny);

                        if (blocked.Contains(np))
                            continue;

                        grid[x, y].Edges.Add(
                            new Edge<Point>(
                                grid[x, y],
                                grid[nx, ny],
                                1
                            )
                        );
                    }
                }
            }

            Vertex<Point> start = grid[0, 19];
            Vertex<Point> end = grid[19, 0];

            // Act
            List<Edge<Point>> path = graph.AStar(start, end);

            // Assert
            Assert.IsNotNull(path);

            // Ensure path reaches target
            Assert.AreEqual(end, path[^1].EndVertex);

            // Ensure no blocked tiles are used
            foreach (var edge in path)
            {
                Assert.IsFalse(blocked.Contains(edge.StartVertex.Value));
                Assert.IsFalse(blocked.Contains(edge.EndVertex.Value));
            }

            // Optional debug output
            Console.WriteLine($"Path length: {path.Count}");
        }

        [TestMethod]
        public void Pathfind_ShouldReturnCorrectPath()
        {
            // Arrange
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };
            var d = new Vertex<string>("D") { Edges = new List<Edge<string>>() };
            var e = new Vertex<string>("E") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] { a, b, c, d, e });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var ac = new Edge<string>(a, c, 2);
            var cd = new Edge<string>(c, d, 4);
            var bd = new Edge<string>(b, d, 1);
            var de = new Edge<string>(d, e, 1);
            var be = new Edge<string>(b, e, 3);



            a.Edges.Add(ab);
            a.Edges.Add(ac);
            b.Edges.Add(bd);
            c.Edges.Add(cd);
            d.Edges.Add(de);
            b.Edges.Add(be);


            // Act
            var path = graph.Pathfindgood(a, e);

            // Assert
            Assert.IsNotNull(path);
            Assert.AreEqual(3, path.Count);

        }
        [TestMethod]
        public void NegativeLoop()
        {
            // Arrange
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };


            graph.vertices.AddRange(new[] { a, b, c });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var bc = new Edge<string>(b, c, 1);
            var ca = new Edge<string>(c, a, -4);




            a.Edges.Add(ab);
            b.Edges.Add(bc);
            c.Edges.Add(ca);



            // Act
            bool path = graph.BellmanFord(a);

            // Assert
            Assert.IsTrue(path);

        }
        [TestMethod]
        public void NegativeLoop2()
        {
            // Arrange
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };


            graph.vertices.AddRange(new[] { a, b, c });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var bc = new Edge<string>(b, c, 1);
            var ca = new Edge<string>(c, a, -1);




            a.Edges.Add(ab);
            b.Edges.Add(bc);
            c.Edges.Add(ca);



            // Act
            bool path = graph.BellmanFord(a);

            // Assert
            Assert.IsFalse(path);

        }
        [TestMethod]
        public void NegativeLoop3()
        {
            Graph<string> graph = new Graph<string>();

            var s = new Vertex<string>("s") { Edges = new List<Edge<string>>() };
            var q = new Vertex<string>("q") { Edges = new List<Edge<string>>() };
            var r = new Vertex<string>("r") { Edges = new List<Edge<string>>() };
            var p = new Vertex<string>("p") { Edges = new List<Edge<string>>() };
            var f = new Vertex<string>("f") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] {s, q, r, p, f });

            // Manually connect edges (since AddEdge is buggy)
            var sq = new Edge<string>(s, q,1);
            var qr = new Edge<string>(q, r, 5);
            var rp = new Edge<string>(r, p, -50);
            var sp = new Edge<string>(s, p, 2);
            var rf = new Edge<string>(r, f, 100);
            var pf = new Edge<string>(p, f, 100);



            s.Edges.Add(sq);
            q.Edges.Add(qr);
            r.Edges.Add(rp);
            s.Edges.Add(sp);
            r.Edges.Add(rf);
            p.Edges.Add(pf);



            bool path = graph.BellmanFord(s);

            // Assert
            Assert.IsFalse(path);

        }
        [TestMethod]
        public void Pathfindimpossible()
        {
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };
            var d = new Vertex<string>("D") { Edges = new List<Edge<string>>() };
            var e = new Vertex<string>("E") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] { a, b, c, d, e });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var ac = new Edge<string>(a, c, 2);
            var cd = new Edge<string>(c, d, 4);
            var bd = new Edge<string>(b, d, 1);
            var de = new Edge<string>(d, e, 1);
            var be = new Edge<string>(b, e, 3);

            
            a.Edges.Add(ab);
            a.Edges.Add(ac);
            b.Edges.Add(bd);
            c.Edges.Add(cd);


            // Act
            List<Edge<string>> path = graph.Pathfindgood(a, e);

            // Assert
            Assert.IsNull(path);
        }
    }
}
