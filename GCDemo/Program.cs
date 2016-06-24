using System;

namespace GCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Runtime rt = new Runtime(10);

            Number n1 = (Number)rt.CreateObject(typeof(Number));
            n1.Value = 1;
            Number n2 = (Number)rt.CreateObject(typeof(Number));
            n2.Value = 2;
            Number n3 = (Number)rt.CreateObject(typeof(Number));
            n3.Value = 3;

            Numbers numbers = (Numbers)rt.CreateObject(typeof(Numbers));
            numbers.Print();
            numbers.RemoveLast();

            numbers.Print();
            rt.CollectGarbage();
        }
    }
}
