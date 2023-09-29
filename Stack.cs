using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLab3_CSharp {
    public class StackEnumerator : IEnumerator {
        private Node _node;
        private Node _startnode;
        private int _pos = -1;
        private int _len;

        public StackEnumerator( Node node, int len ) {
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

            _node = (Node) _node.Next;
            _pos++;
            return _pos < _len;
        }

        public void Reset() {
            _pos = -1;
            _node = _startnode;
        }
    }

    public class Stack {
        public Node? Start { get; protected set; }
        public Node? End { get; protected set; }
        int Length;

        public IEnumerator GetEnumerator() {
            if (Start == null) { throw new InvalidOperationException(); }
            return new StackEnumerator( Start, Length );
        }

        public Stack() {
            Length = 0;
        }

        public Stack( Node? start) {
            Start = start;
            End = start;
            Length = 1;
        }

        public void Push(Node node ) {
            if (Start == null || End == null) {
                Start = node;
                End = node;
                return;
            }

            End.Next = node;
            End = node;
        }

        public int Pop() {
            if (End == null || Start == null) throw new InvalidOperationException();
            int data = End.Data;

            if (Start == End) {
                Start = null;
                End = null;
                return data;
            }

            foreach (Node item in this) {
                if (item.Next == End) {
                    item.Next = null;
                    End = item;
                    return data;
                }
            }

            return data;
        }

    }
}
