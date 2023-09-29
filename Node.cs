using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLab3_CSharp{
    public class Node{

        public int Data { get; set; }
        public Node? Next { get; set; }

        public Node(int data) {
            Data = data;
        }

        public Node(int data, Node? next) {
            Data = data;
            Next =  next;
        }

        public override string ToString() {
            return Data.ToString();
        }

        public virtual Node Copy() {
            if (Next == null) {
                return new Node( Data );
            } else {
                return new Node( Data, Next );
            }
        }
    }
}
