using System;
using System.Collections.Generic;

namespace RedBlackTree
{
    public class RedBlackTreeConsoleVisualizer<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> tree;

        private const int NodeWidth = 9;
        private const int LevelHeight = 4;
        private const int HorizontalGap = 2;

        public RedBlackTreeConsoleVisualizer(
            RedBlackTree<T> tree)
        {
            this.tree = tree
                ?? throw new ArgumentNullException(nameof(tree));
        }

        // ============================================================
        // PUBLIC METHOD
        // ============================================================

        public void Show()
        {
            Console.Clear();

            PrintHeader();

            if (tree.root == null)
            {
                Console.WriteLine();
                Console.WriteLine("Tree is empty.");
                return;
            }

            Console.WriteLine();

            DrawTree();

            Console.WriteLine();

            PrintStatistics();

            Console.WriteLine();

            PrintLegend();
        }

        // ============================================================
        // HEADER
        // ============================================================

        private void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(
                "+------------------------------------------------------------+"
            );

            Console.WriteLine(
                "|                 RED-BLACK TREE VISUALIZER                 |"
            );

            Console.WriteLine(
                "+------------------------------------------------------------+"
            );

            Console.ResetColor();
        }

        // ============================================================
        // TREE DRAWING
        // ============================================================

        private void DrawTree()
        {
            int height = GetHeight(tree.root);

            /*
             * Number of slots at the bottom level.
             *
             * height 1 -> 1
             * height 2 -> 2
             * height 3 -> 4
             * height 4 -> 8
             */
            int slots = 1;

            for (int i = 1; i < height; i++)
            {
                slots *= 2;
            }

            /*
             * Width of the complete canvas.
             */
            int canvasWidth =
                Math.Max(
                    80,
                    slots * (NodeWidth + HorizontalGap)
                );

            /*
             * Don't let enormous trees destroy the console.
             */
            if (canvasWidth > 240)
            {
                Console.ForegroundColor =
                    ConsoleColor.Yellow;

                Console.WriteLine(
                    "Tree is too wide for the console."
                );

                Console.ResetColor();

                DrawFallback(tree.root, "", true);

                return;
            }

            /*
             * 2D character canvas.
             *
             * Every character starts as a space.
             */
            char[,] canvas =
                new char[
                    height * LevelHeight,
                    canvasWidth
                ];

            for (int y = 0;
                 y < canvas.GetLength(0);
                 y++)
            {
                for (int x = 0;
                     x < canvas.GetLength(1);
                     x++)
                {
                    canvas[y, x] = ' ';
                }
            }

            /*
             * Store exact coordinates for every node.
             */
            Dictionary<Node<T>, Point> positions =
                new Dictionary<Node<T>, Point>();

            /*
             * Calculate node positions.
             */
            CalculatePositions(
                tree.root,
                0,
                0,
                canvasWidth,
                positions
            );

            /*
             * Draw connections FIRST.
             */
            foreach (
                KeyValuePair<Node<T>, Point> pair
                in positions)
            {
                Node<T> node = pair.Key;
                Point parent = pair.Value;

                if (node.Left != null &&
                    positions.ContainsKey(node.Left))
                {
                    DrawConnection(
                        canvas,
                        parent,
                        positions[node.Left],
                        true
                    );
                }

                if (node.Right != null &&
                    positions.ContainsKey(node.Right))
                {
                    DrawConnection(
                        canvas,
                        parent,
                        positions[node.Right],
                        false
                    );
                }
            }

            /*
             * Draw nodes ON TOP of the connections.
             */
            foreach (
                KeyValuePair<Node<T>, Point> pair
                in positions)
            {
                DrawNode(
                    canvas,
                    pair.Key,
                    pair.Value
                );
            }

            /*
             * Finally print the canvas.
             */
            PrintCanvas(
                canvas,
                positions
            );
        }

        // ============================================================
        // CALCULATE NODE POSITIONS
        // ============================================================

        private void CalculatePositions(
            Node<T> node,
            int depth,
            int slot,
            int canvasWidth,
            Dictionary<Node<T>, Point> positions)
        {
            if (node == null)
                return;

            int slotsAtLevel =
                1 << depth;

            /*
             * Divide the entire canvas into equal sections.
             *
             * At level 0:
             *
             *                    50
             *
             * At level 1:
             *
             *              25          75
             *
             * At level 2:
             *
             *          10      30    60      90
             */

            int sectionWidth =
                canvasWidth / slotsAtLevel;

            int x =
                (slot * sectionWidth)
                + (sectionWidth / 2);

            /*
             * Account for the width of the node itself.
             */
            x -= NodeWidth / 2;

            int y =
                depth * LevelHeight;

            positions[node] =
                new Point(x, y);

            /*
             * Left child.
             */
            CalculatePositions(
                node.Left,
                depth + 1,
                slot * 2,
                canvasWidth,
                positions
            );

            /*
             * Right child.
             */
            CalculatePositions(
                node.Right,
                depth + 1,
                slot * 2 + 1,
                canvasWidth,
                positions
            );
        }

        // ============================================================
        // DRAW CONNECTION
        // ============================================================

        private void DrawConnection(
            char[,] canvas,
            Point parent,
            Point child,
            bool left)
        {
            /*
             * Parent center.
             */
            int parentCenter =
                parent.X + NodeWidth / 2;

            /*
             * Child center.
             */
            int childCenter =
                child.X + NodeWidth / 2;

            /*
             * Start underneath parent.
             */
            int startY =
                parent.Y + 1;

            /*
             * End above child.
             */
            int endY =
                child.Y - 1;

            if (endY <= startY)
                return;

            /*
             * Draw a simple diagonal:
             *
             *       [50]
             *       /
             *     [25]
             *
             * or
             *
             *       [50]
             *          \
             *          [75]
             */

            for (int y = startY;
                 y <= endY;
                 y++)
            {
                double progress =
                    (double)(y - startY)
                    / (endY - startY);

                int x =
                    (int)Math.Round(
                        parentCenter +
                        (childCenter - parentCenter)
                        * progress
                    );

                if (x < 0 ||
                    x >= canvas.GetLength(1))
                {
                    continue;
                }

                char character;

                if (childCenter < parentCenter)
                {
                    character = '/';
                }
                else
                {
                    character = '\\';
                }

                canvas[y, x] = character;
            }
        }

        // ============================================================
        // DRAW NODE
        // ============================================================

        private void DrawNode(
            char[,] canvas,
            Node<T> node,
            Point position)
        {
            if (node == null)
                return;

            string value =
                node.Value?.ToString()
                ?? "null";

            string text =
                $"[{(node.IsRed ? "R" : "B")}:{value}]";

            /*
             * Make every node the same width.
             */
            if (text.Length < NodeWidth)
            {
                int padding =
                    NodeWidth - text.Length;

                int left =
                    padding / 2;

                int right =
                    padding - left;

                text =
                    new string(' ', left)
                    + text
                    + new string(' ', right);
            }

            /*
             * If somehow the value is bigger than NodeWidth,
             * allow it to expand.
             */
            if (text.Length > NodeWidth)
            {
                NodeWidthWarning();
            }

            for (int i = 0;
                 i < text.Length;
                 i++)
            {
                int x =
                    position.X + i;

                int y =
                    position.Y;

                if (x < 0 ||
                    x >= canvas.GetLength(1) ||
                    y < 0 ||
                    y >= canvas.GetLength(0))
                {
                    continue;
                }

                canvas[y, x] =
                    text[i];
            }
        }

        // ============================================================
        // PRINT CANVAS
        // ============================================================

        private void PrintCanvas(
            char[,] canvas,
            Dictionary<Node<T>, Point> positions)
        {
            /*
             * We need to know which characters belong to nodes
             * so we can color them.
             */
            Dictionary<Point, Node<T>> nodeLocations =
                new Dictionary<Point, Node<T>>();

            foreach (
                KeyValuePair<Node<T>, Point> pair
                in positions)
            {
                nodeLocations[pair.Value] =
                    pair.Key;
            }

            for (int y = 0;
                 y < canvas.GetLength(0);
                 y++)
            {
                /*
                 * Don't print completely empty lines.
                 */
                bool hasContent = false;

                for (int x = 0;
                     x < canvas.GetLength(1);
                     x++)
                {
                    if (canvas[y, x] != ' ')
                    {
                        hasContent = true;
                        break;
                    }
                }

                if (!hasContent)
                    continue;

                /*
                 * Print each character.
                 *
                 * Nodes are colored according to their
                 * red/black state.
                 */
                int xPos = 0;

                while (xPos < canvas.GetLength(1))
                {
                    Node<T> node =
                        FindNodeAtCharacter(
                            positions,
                            y,
                            xPos
                        );

                    if (node != null)
                    {
                        Point p =
                            positions[node];

                        string value =
                            node.Value?.ToString()
                            ?? "null";

                        string text =
                            $"[{(node.IsRed ? "R" : "B")}:{value}]";

                        if (text.Length < NodeWidth)
                        {
                            int padding =
                                NodeWidth - text.Length;

                            int left =
                                padding / 2;

                            int right =
                                padding - left;

                            text =
                                new string(' ', left)
                                + text
                                + new string(' ', right);
                        }

                        if (node.IsRed)
                        {
                            Console.ForegroundColor =
                                ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor =
                                ConsoleColor.White;
                        }

                        Console.Write(text);

                        Console.ResetColor();

                        xPos += text.Length;

                        continue;
                    }

                    Console.Write(
                        canvas[y, xPos]
                    );

                    xPos++;
                }

                Console.WriteLine();
            }
        }

        // ============================================================
        // FIND NODE AT CHARACTER
        // ============================================================

        private Node<T> FindNodeAtCharacter(
            Dictionary<Node<T>, Point> positions,
            int y,
            int x)
        {
            foreach (
                KeyValuePair<Node<T>, Point> pair
                in positions)
            {
                Node<T> node =
                    pair.Key;

                Point point =
                    pair.Value;

                if (y != point.Y)
                    continue;

                string value =
                    node.Value?.ToString()
                    ?? "null";

                string text =
                    $"[{(node.IsRed ? "R" : "B")}:{value}]";

                int width =
                    Math.Max(
                        NodeWidth,
                        text.Length
                    );

                if (x >= point.X &&
                    x < point.X + width)
                {
                    return node;
                }
            }

            return null;
        }

        // ============================================================
        // STATISTICS
        // ============================================================

        private void PrintStatistics()
        {
            int nodes =
                CountNodes(tree.root);

            int height =
                GetHeight(tree.root);

            int blackHeight =
                GetBlackHeight(tree.root);

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                "+----------------+----------------+----------------------+"
            );

            Console.Write(
                "| "
            );

            Console.ForegroundColor =
                ConsoleColor.White;

            Console.Write(
                $"NODES: {nodes,-9}"
            );

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.Write(
                " | "
            );

            Console.ForegroundColor =
                ConsoleColor.White;

            Console.Write(
                $"HEIGHT: {height,-8}"
            );

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.Write(
                " | "
            );

            Console.ForegroundColor =
                ConsoleColor.White;

            Console.Write(
                $"BLACK HEIGHT: {blackHeight,-8}"
            );

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                " |"
            );

            Console.WriteLine(
                "+----------------+----------------+----------------------+"
            );

            Console.ResetColor();
        }

        // ============================================================
        // LEGEND
        // ============================================================

        private void PrintLegend()
        {
            Console.WriteLine(
                "------------------------------------------------------------"
            );

            Console.ForegroundColor =
                ConsoleColor.Red;

            Console.Write("[R]");

            Console.ResetColor();

            Console.Write(
                " = RED     "
            );

            Console.ForegroundColor =
                ConsoleColor.White;

            Console.Write("[B]");

            Console.ResetColor();

            Console.WriteLine(
                " = BLACK"
            );

            Console.WriteLine(
                "------------------------------------------------------------"
            );
        }

        // ============================================================
        // FALLBACK
        // ============================================================

        private void DrawFallback(
            Node<T> node,
            string indent,
            bool last)
        {
            if (node == null)
                return;

            Console.Write(indent);

            Console.Write(
                last
                    ? "`-- "
                    : "|-- "
            );

            PrintColoredNode(node);

            Console.WriteLine();

            string nextIndent =
                indent +
                (last
                    ? "    "
                    : "|   ");

            if (node.Left != null)
            {
                DrawFallback(
                    node.Left,
                    nextIndent,
                    node.Right == null
                );
            }

            if (node.Right != null)
            {
                DrawFallback(
                    node.Right,
                    nextIndent,
                    true
                );
            }
        }

        private void PrintColoredNode(
            Node<T> node)
        {
            string value =
                node.Value?.ToString()
                ?? "null";

            string text =
                $"[{(node.IsRed ? "R" : "B")}:{value}]";

            if (node.IsRed)
            {
                Console.ForegroundColor =
                    ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor =
                    ConsoleColor.White;
            }

            Console.Write(text);

            Console.ResetColor();
        }

        // ============================================================
        // TREE INFORMATION
        // ============================================================

        private int CountNodes(
            Node<T> node)
        {
            if (node == null)
                return 0;

            return
                1 +
                CountNodes(node.Left) +
                CountNodes(node.Right);
        }

        private int GetHeight(
            Node<T> node)
        {
            if (node == null)
                return 0;

            return
                1 +
                Math.Max(
                    GetHeight(node.Left),
                    GetHeight(node.Right)
                );
        }

        private int GetBlackHeight(
            Node<T> node)
        {
            if (node == null)
                return 1;

            int left =
                GetBlackHeight(node.Left);

            int right =
                GetBlackHeight(node.Right);

            int result =
                Math.Max(left, right);

            if (!node.IsRed)
                result++;

            return result;
        }

        // ============================================================
        // WARNING
        // ============================================================

        private void NodeWidthWarning()
        {
            // Intentionally empty.
            // Long values are allowed to expand.
        }

        // ============================================================
        // POINT
        // ============================================================

        private class Point
        {
            public int X;
            public int Y;

            public Point(
                int x,
                int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(
                object obj)
            {
                Point other =
                    obj as Point;

                if (other == null)
                    return false;

                return
                    X == other.X &&
                    Y == other.Y;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    }
}
