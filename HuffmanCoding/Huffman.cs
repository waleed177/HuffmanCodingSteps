using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding {
    public class Huffman {
        public static string ByteToString(byte data) {
            return (Form1.useASCII ? ((char)data).ToString() : data.ToString());
        }

        public class HuffmanNode : IComparable<HuffmanNode> {
            public byte data;
            public int frequency;
            public Node<HuffmanNode> treeNode;

            public HuffmanNode(byte data, int frequency, Node<HuffmanNode> treeNode = null) {
                this.data = data;
                this.frequency = frequency;
                this.treeNode = treeNode;
            }

            public int CompareTo(HuffmanNode other) {
                return frequency - other.frequency;
            }

            public override string ToString() {
                return ByteToString(data) + "," + frequency;
            }
        }

        public abstract class HuffmanStep {

            public abstract void Draw(Graphics g, Font Font, float width, float totalHeight);

        }

        public class HuffmanTreeGenStep : HuffmanStep {
            public List<Node<HuffmanNode>> HuffmanTrees;
            public BinaryTree<HuffmanNode> HeapTree;

            public HuffmanTreeGenStep(List<Node<HuffmanNode>> huffmanTrees, BinaryTree<HuffmanNode> heapTree) {
                HuffmanTrees = huffmanTrees;
                HeapTree = heapTree;
            }

            public override void Draw(Graphics g, Font Font, float width, float totalHeight) {
                float xoffset = 0;

                foreach (var item in HuffmanTrees) {
                    item.Draw(g, Font, width, xoffset, 0);
                    xoffset += 32 * item.ChildrenAmount;
                }

                g.DrawLine(Pens.Black, xoffset, 0, xoffset, totalHeight);

                HeapTree.root.Draw(g, Font, 32, xoffset, 0);
            }
        }

        public class DictionaryGenerationStep : HuffmanStep {
            public Node<HuffmanNode> root;
            public HashSet<Node<HuffmanNode>> nodes;
            public List<(byte, string)> dictionary;

            public override void Draw(Graphics g, Font Font, float width, float totalHeight) {
                root.Draw(g, Font, width, 0, 0, nodes);

                for (var i = 0; i < dictionary.Count; i++) {
                    (byte key, string value) = dictionary[i];
                    g.DrawString(ByteToString(key) + " -> " + value, Font, Brushes.Black, 0, 200 + i * 16);
                }
            }
        }

        public class EncodingStep : HuffmanStep {
            public List<(byte, string)> encodingArray;
            public Func<string> arr;
            public Func<string> currentlyBeingAdded;
            public string res;

            public override void Draw(Graphics g, Font Font, float width, float totalHeight) {
                g.DrawString("Data: " + arr() + "\nCurrent:" + currentlyBeingAdded() + "\nRes:" + res, Font, Brushes.Black, 0, 0);

                for (var i = 0; i < encodingArray.Count; i++) {
                    (byte key, string value) = encodingArray[i];
                    g.DrawString(ByteToString(key) + " -> " + value, Font, Brushes.Black, 0, 200 + i * 16);
                }
            }
        }

        public class DecodingStep : HuffmanStep {
            public Node<HuffmanNode> root;
            public string encoded = "";
            public string hint = "";
            public string decoded = "";
            public HashSet<Node<HuffmanNode>> nodes;
            internal string hintASCII;
            internal string decodedASCII;

            public override void Draw(Graphics g, Font Font, float width, float totalHeight) {
                root.Draw(g, Font, width, 0, 0, nodes);

                g.DrawString("Encoded: " + encoded + "\nCurrent:" + (Form1.useASCII ? hintASCII : hint) + "\nDecoded:" + (Form1.useASCII ? decodedASCII : decoded), Font, Brushes.Black, 0, 200);
            }
        }

        public class HuffmanResults {
            public int[] frequency;
            public List<HuffmanStep> steps;
            public Dictionary<byte, string> encodingDictionary;
            public BitArray encodedData;
            public Node<HuffmanNode> treeRoot;
            public List<(byte, string)> encodingArray; //Exactly the same as the encoding dictionary, but used for renderering to ensure order.
        }


        public static List<T> CloneArray<T>(List<T> arr) {
            List<T> res = new List<T>();
            for (int i = 0; i < arr.Count; i++)
                res.Add(arr[i]);
            return res;
        }
        public static HashSet<T> CloneHashSet<T>(HashSet<T> arr) {
            HashSet<T> res = new HashSet<T>();
            foreach (var item in arr)
                res.Add(item);
            return res;
        }

        public static HuffmanResults GenerateHuffmanEverythingSteps(byte[] data) {
            BinaryTree<HuffmanNode> tree = new BinaryTree<HuffmanNode>();
            HuffmanResults res = new HuffmanResults();
            res.steps = new List<HuffmanStep>();
            res.encodingDictionary = new Dictionary<byte, string>();
            res.frequency = new int[256];

            Heap<HuffmanNode> heap = new Heap<HuffmanNode>(256);
            List<Node<HuffmanNode>> trees = new List<Node<HuffmanNode>>();

            for (int i = 0; i < data.Length; i++)
                res.frequency[data[i]]++;
            for (int i = 0; i < res.frequency.Length; i++)
                if (res.frequency[i] != 0) { //for now, this is better for displaying.
                    HuffmanNode item = new HuffmanNode((byte)i, res.frequency[i]);
                    item.treeNode = new Node<HuffmanNode>(item);
                    item.treeNode.Tree = tree;
                    heap.Add(item);
                    trees.Add(item.treeNode);
                }


            List<Node<HuffmanNode>> leafs = CloneArray(trees);
            res.steps.Add(new HuffmanTreeGenStep(leafs, heap.ConvertToTree()));


            while (heap.Count >= 2) {

                HuffmanNode node1 = heap.Pop();
                HuffmanNode node2 = heap.Pop();
                HuffmanNode nodeParent = new HuffmanNode(0, node1.frequency + node2.frequency);

                trees.Remove(node1.treeNode);
                trees.Remove(node2.treeNode);

                Node<HuffmanNode> treeNode = new Node<HuffmanNode>(nodeParent, node1.treeNode, node2.treeNode);
                treeNode.Tree = tree;
                nodeParent.treeNode = treeNode;

                trees.Add(treeNode);

                heap.Add(nodeParent);

                res.steps.Add(new HuffmanTreeGenStep(CloneArray(trees), heap.ConvertToTree()));
            }


            //Generate dictionary for encoding
            Node<HuffmanNode> treeRoot = trees[0];
            res.treeRoot = treeRoot;
            List<(byte, string)> encodingArray = new List<(byte, string)>();

            //for every leaf go up until you reach parent.
            for (int i = 0; i < leafs.Count; i++) {
                Node<HuffmanNode> currentNode = leafs[i];
                List<bool> encoding = new List<bool>();
                HashSet<Node<HuffmanNode>> nodesTraversed = new HashSet<Node<HuffmanNode>>();
                string bitArray = "";

                while (currentNode.Parent != null) {
                    Node<HuffmanNode> parent = currentNode.Parent;
                    if (currentNode == parent.Left) {
                        bitArray = "1" + bitArray;
                    } else {
                        bitArray = "0" + bitArray;
                    }
                    nodesTraversed.Add(currentNode);
                    currentNode = parent;
                }
                nodesTraversed.Add(currentNode);
                encodingArray.Add((leafs[i].value.data, bitArray));
                res.encodingDictionary.Add(leafs[i].value.data, bitArray);

                DictionaryGenerationStep dictStep = new DictionaryGenerationStep();
                dictStep.root = treeRoot;
                dictStep.nodes = nodesTraversed;
                dictStep.dictionary = CloneArray(encodingArray);
                res.steps.Add(dictStep);
            }

            res.encodingArray = encodingArray;
            //Encoding
            string resultingEncoding = HuffmanEncode(data, res);

            HuffmanDecode(res, resultingEncoding);

            return res;
        }

        public static void HuffmanDecode(HuffmanResults res, string encodedData) {
            string resultingDecoding = "";
            string resultingDecodingASCII = "";
            Node<HuffmanNode> currentNode = null;

            string hint = "";
            string hintASCII = "";
            HashSet<Node<HuffmanNode>> traversedNodes = new HashSet<Node<HuffmanNode>>();
            for (int i = 0; i < encodedData.Length; i++) {
                DecodingStep decodingStep = new DecodingStep();

                char item = encodedData[i];

                if (currentNode == null) currentNode = res.treeRoot;

                if (item == '1') {
                    currentNode = currentNode.Left;
                    traversedNodes.Add(currentNode);
                    hint += "1";
                    hintASCII += "1";
                } else {
                    currentNode = currentNode.Right;
                    traversedNodes.Add(currentNode);
                    hint += "0";
                    hintASCII += "0";
                }

                if (currentNode.Left == null) {
                    resultingDecoding += currentNode.value.data + ",";
                    resultingDecodingASCII += (char)currentNode.value.data + ",";
                    hint += " Found leaf node, Decoded value is: " + currentNode.value.data;
                    hintASCII += " Found leaf node, Decoded value is: " + (char)currentNode.value.data;
                    traversedNodes.Add(currentNode);
                    currentNode = null;
                }

                decodingStep.hint = hint;
                decodingStep.hintASCII = hintASCII;
                decodingStep.encoded = encodedData;
                decodingStep.decoded = resultingDecoding;
                decodingStep.decodedASCII = resultingDecodingASCII;
                decodingStep.root = res.treeRoot;
                decodingStep.nodes = CloneHashSet(traversedNodes);
                if (currentNode == null) {
                    traversedNodes = new HashSet<Node<HuffmanNode>>();
                    hint = "";
                    hintASCII = "";
                }
                res.steps.Add(decodingStep);
            }
        }

        public static string HuffmanEncode(byte[] data, HuffmanResults res) {
            string resultingEncoding = "";

            for (int i = 0; i < data.Length; i++) {
                EncodingStep encodingStep = new EncodingStep();
                byte item = data[i];
                encodingStep.currentlyBeingAdded = () => "Encoding " + ByteToString(item) + " as " + res.encodingDictionary[item];
                resultingEncoding += res.encodingDictionary[item];
                encodingStep.res = resultingEncoding;
                encodingStep.encodingArray = res.encodingArray;
                encodingStep.arr = () => string.Join(",", data.Select((b) => ByteToString(b))); //there is definitely a better way, but idc rn.
                res.steps.Add(encodingStep);
            }

            return resultingEncoding;
        }
    }
}
