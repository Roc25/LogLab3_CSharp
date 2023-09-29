
using LogLab3_CSharp;

class Program {

    static void Main() {
        LogLab3_CSharp.PriorityQueue Q = new();

        PriorityNode noda1 = new(1, 500);
        PriorityNode noda2 = new(2, 4);
        PriorityNode noda3 = new(3, 1);
        PriorityNode noda4 = new(4, 250);
        PriorityNode noda5 = new(5, 1000);

        Q.Add(noda1);
        Q.Add(noda2);
        Q.Add(noda3);
        Q.Add(noda4);
        Q.Add(noda5);

        foreach(PriorityNode node in Q) {
            Console.WriteLine(node);
        }

        
    }
}