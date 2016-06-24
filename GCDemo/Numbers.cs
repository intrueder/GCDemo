using System;

namespace GCDemo
{
    class Numbers : SystemObject
    {
        public Number Head { get; private set; }

        public Numbers Tail;

        public void Add(Number elem)
        {
            if (!IsEmpty)
            {
                Tail.Add(Head);
                Head = elem;
            }
            else
            {
                Head = elem;
                Tail = new Numbers();
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty)
            {
                return;
            }

            if (Tail.IsEmpty)
            {
                Head = null;
                return;
            }

            Tail.RemoveLast();
        }

        public void Print()
        {
            Console.Write(" {0} ", Head?.Value);
            Tail?.Print();
        }

        public bool IsEmpty => Head == null;
    }
}
