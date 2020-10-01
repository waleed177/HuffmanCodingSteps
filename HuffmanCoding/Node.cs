using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding {

    public class Node<T> {
        public Node<T> Parent { get; set; }

        private BinaryTree<T> backing_field_tree;
        public BinaryTree<T> Tree {
            get => backing_field_tree;

            set {
                backing_field_tree = value;
                if (Left != null) Left.Tree = value;
                if (Right != null) Right.Tree = value;
            }
        }

        public T value;
        private Node<T> backingfield_left;
        private Node<T> backingfield_right;

        public Node<T> Left {
            set {
                backingfield_left = value;
                if (value != null) {
                    value.Tree = Tree;
                    value.Parent = this;
                }

                ChildrenAmount = GetChildrenAmount(backingfield_left) + GetChildrenAmount(backingfield_right) + 1;
            }

            get => backingfield_left;
        }

        public Node<T> Right {
            set {
                backingfield_right = value;
                if (value != null) {
                    value.Tree = Tree;
                    value.Parent = this;
                }
                ChildrenAmount = GetChildrenAmount(backingfield_left) + GetChildrenAmount(backingfield_right) + 1;
            }

            get => backingfield_right;
        }

        public int ChildrenAmount { get; private set; } = 1;

        public Node(T value, Node<T> left = null, Node<T> right = null) {
            this.value = value;
            Left = left;
            Right = right;
        }

        private static int GetChildrenAmount(Node<T> tree) {
            if (tree == null)
                return 0;
            else return tree.ChildrenAmount;
        }

        public void Draw(Graphics g, Font font, float width, float xoffset, float yoffset, HashSet<Node<T>> linesHighlighted = null, HashSet<Node<T>> nodesHighlighted = null) {
            float leftWidth = GetChildrenAmount(Left) * width;
            PointF root = new PointF(xoffset + leftWidth + width / 2, yoffset + width / 2);

            Pen LineColor(Node<T> node) {
                if (linesHighlighted != null && linesHighlighted.Contains(node))
                    return Tree.highlightedLine;
                else return Tree.normalLine;
            }

            Brush NodeColor = nodesHighlighted != null && nodesHighlighted.Contains(this) ? Tree.nodeHighlightedColor : Tree.nodeNormalColor;

            if (Left != null)
                g.DrawLine(LineColor(Left), root, new PointF(xoffset + GetChildrenAmount(Left.Left) * width + width / 2, yoffset + width + width / 2));
            if (Right != null)
                g.DrawLine(LineColor(Right), root, new PointF(xoffset + leftWidth + width + GetChildrenAmount(Right.Left) * width + width / 2, yoffset + width + width / 2));
            Left?.Draw(g, font, width, xoffset, yoffset + width, linesHighlighted);
            Right?.Draw(g, font, width, xoffset + leftWidth + width, yoffset + width, linesHighlighted);

            g.FillPie(NodeColor, root.X - width / 2, root.Y - width / 2, width, width, 0, 360);



            g.DrawString(value.ToString(), font, Brushes.Black, root, Tree.stringFormatting);

        }
    }
}
