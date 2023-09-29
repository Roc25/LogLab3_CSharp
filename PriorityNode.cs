using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLab3_CSharp {
    public class PriorityNode : Node {

        public int Priority { get; protected set; }
        public PriorityQueue? Queue { get; internal set; }

        public PriorityNode( int data, int priority ) : base( data ) {
            Priority = priority;
            Queue = null;
        }

        public PriorityNode( int data, int priority, PriorityQueue queue ) : base( data ) {
            Priority = priority;
            Queue = queue;
        }

        public void Remove() { //Можем удалить Узел конкретный узел, без обращения к самой очереди
            if (Queue == null || Queue.Start == null) throw new InvalidOperationException();

            if (Queue.Start.Next == this) Queue.Start = (PriorityNode?) Next;

            foreach (PriorityNode item in Queue) {
                if (item.Next == this) {
                    item.Next = this.Next;
                }
            }

            Queue = null;
        }

        public int Pop() { //Можем удалить Узел конкретный узел, без обращения к самой очереди
            if (Queue == null || Queue.Start == null) return Data;

            if (Queue.Start.Next == this) Queue.Start = (PriorityNode?) Next;

            foreach (Node item in Queue) {
                if (item.Next == this) {
                    item.Next = this.Next;
                }
            }

            Queue = null;

            return Data;
        }

        public override PriorityNode Copy() {
            if (Queue == null) {
                return new PriorityNode( Data, Priority );
            }
            return new PriorityNode( Data, Priority, Queue );
        }

        public PriorityNode FindPreviouse() {
            if (Queue == null || Queue.Start == null) throw new InvalidOperationException();

            foreach (PriorityNode item in Queue) {
                if (item.Next == this) {
                    return item;
                }
            }
            return Queue.Start;
        }

        public override string ToString() {
            return Data.ToString() + " " + Priority.ToString();
        }
    }
}
