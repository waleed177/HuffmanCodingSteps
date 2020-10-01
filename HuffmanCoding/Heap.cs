using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding {
    public class Heap<T> where T : IComparable<T> {
        public T[] heapArray;
        public int Count { get; private set; } = 0;

        public Heap(int size) {
            heapArray = new T[size];
        }

        public void Add(T item) {
            heapArray[Count] = item;
            Count++;
            ReheapUp(Count - 1);
        }

        public T Pop() {
            T res = heapArray[0];
            heapArray[0] = heapArray[Count - 1];
            Count--;
            ReheapDown(0);
            return res;
        }


        private void ReheapDown(int id) {
            int leftChildId = GetLeftChildId(id);
            int rightChildId = GetRightChildId(id);
            if (id >= Count || leftChildId >= Count) return;
            T leftChild = heapArray[leftChildId];
            T rightChild;
            int minChildId = leftChildId;

            if (rightChildId < Count) {
                rightChild = heapArray[rightChildId];
                if (leftChild.CompareTo(rightChild) > 0)
                    minChildId = rightChildId;
            }

            T currentNode = heapArray[id];
            if (heapArray[minChildId].CompareTo(currentNode) < 0) {
                heapArray[id] = heapArray[minChildId];
                heapArray[minChildId] = currentNode;
                ReheapDown(minChildId);
            }
        }

        private void ReheapUp(int id) {
            if (1 > id || id >= Count) return;
            int parentId = GetParentId(id);
            T parent = heapArray[parentId];
            T currentNode = heapArray[id];

            if (parent.CompareTo(currentNode) > 0) {
                heapArray[id] = heapArray[parentId];
                heapArray[parentId] = currentNode;
                ReheapUp(parentId);
            }
        }

        public BinaryTree<T> ConvertToTree() {
            Node<T> ConvertToNode(int id) {
                if (id < 0 || id >= Count) return null;
                return new Node<T>(heapArray[id], ConvertToNode(GetLeftChildId(id)), ConvertToNode(GetRightChildId(id)));
            }

            return new BinaryTree<T>(ConvertToNode(0));
        }

        private int GetLeftChildId(int id) {
            return 2 * id + 1;
        }

        private int GetRightChildId(int id) {
            return 2 * id + 2;
        }

        private int GetParentId(int id) {
            return (id - 1) / 2;
        }
    }
}
