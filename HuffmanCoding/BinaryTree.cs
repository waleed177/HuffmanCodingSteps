using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding {
    public class BinaryTree<T> {
        public StringFormat stringFormatting;
        public Node<T> root;
        public Pen highlightedLine, normalLine;
        public Brush nodeHighlightedColor;
        public Brush nodeNormalColor;

        public BinaryTree(Node<T> node = null) {
            this.root = node;
            if(node != null) node.Tree = this;
            stringFormatting = new StringFormat {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            highlightedLine = new Pen(Brushes.Red, 3);
            normalLine = new Pen(Brushes.Black, 2);
            nodeHighlightedColor = Brushes.Beige;
            nodeNormalColor = Brushes.LightGray;
        }
    }
}
