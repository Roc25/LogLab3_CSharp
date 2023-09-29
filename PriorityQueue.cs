using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLab3_CSharp {
    public class PriorityQueueEnumerator : IEnumerator {
        private PriorityNode _node;
        private PriorityNode _startnode;
        private int _pos = -1;
        private int _len;

        public PriorityQueueEnumerator(PriorityNode node, int len) { 
            _startnode = node;
            _node = node;
            _len = len;
        }

        public Node Current {
            get {
                if (_node == null) {
                    throw new ArgumentException();
                }
                return _node;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext() {
            if (_pos < 0) {
                _pos++;
                return true;
            }

            if (_node.Next == null) return false;

            _node = (PriorityNode) _node.Next;
            _pos++;
            return _pos < _len;
        }

        public void Reset() {
            _node = _startnode;
        }
    }

    public class PriorityQueue {
        public PriorityNode? Start { get; set; }
        public PriorityNode? End { get; set; }
        public int Length { get; private set; } = 0;
        public IEnumerator GetEnumerator() => new PriorityQueueEnumerator( Start, Length );

        public PriorityQueue( PriorityNode start ) {
            start.Queue = this;
            Start = start;
            End = start;
            Length = 1;
        }

        public PriorityQueue() {

        }

        public void Add(PriorityNode node) {
            node.Queue = this;

            if (Start == null || End == null) { 
                Start = node;
                End = node;

                Length += 1;
                return;
            }

            if (Start.Priority < node.Priority) {
                node.Next = Start;
                Start = node;
            }

            foreach (PriorityNode item in this) {
                if (node.Priority > item.Priority) {
                    item.FindPreviouse().Next = node;
                    node.Next = item;
                    Length += 1;
                    return;
                }
            }

            End.Next = node;
            End = node;
            Length += 1;
        }

        public bool Contains(PriorityNode node) {
            foreach (PriorityNode item in this) {
                if (item == node) return true;
            }
            return false;
        }

        public void Swap( PriorityNode node1, PriorityNode node2 ) {
            if (!Contains(node1)) throw new Exception();
            if (!Contains(node2)) throw new Exception();

            PriorityNode temp = node2.Copy();
            if (node1.Next == node2) {
                node1.Next = node2.Next;
                node2.Next = node1;
                node1.FindPreviouse().Next = node2;
            } else if (node2.Next == node1) {
                node2.Next = node1.Next;
                node1.Next = node2;
                node2.FindPreviouse().Next = node1;
            } else {
                node2.Next = node1.Next;
                node1.Next = temp.Next;
                node2.FindPreviouse().Next = node1;
                node1.FindPreviouse().Next = node2;
            }

        }

        public void Remove(PriorityNode node) {
            node.FindPreviouse().Next = node.Next;
            node.Queue = null;
        }

        public void PrioritySort() {
            foreach (PriorityNode i in this) {
                foreach (PriorityNode j in this) {
                    if (i.Priority < j.Priority) {
                        Swap(i, j);
                    }
                }
            }
        }

    }
}
