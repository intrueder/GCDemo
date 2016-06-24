using System;
using System.Collections.Generic;

namespace GCDemo
{
    class Runtime
    {
        int Threshold;
        Stack<SystemObject> stack;
        LinkedList<SystemObject> allrefs;

        public Runtime(int threshold)
        {
            Threshold = threshold;
            stack = new Stack<SystemObject>();
            allrefs = new LinkedList<SystemObject>();
        }

        public SystemObject CreateObject(Type objectType)
        {
            if (Threshold == allrefs.Count)
            {
                CollectGarbage();
            }

            SystemObject obj = (SystemObject)Activator.CreateInstance(objectType);
            obj.IsMarked = false;
            allrefs.AddLast(obj);


            Numbers list = obj as Numbers;
            if (list != null)
            {
                while (stack.Count > 0 && stack.Peek() is Number)
                {
                    list.Add(stack.Pop() as Number);
                }
            }

            stack.Push(obj);

            return obj;
        }

        private void Mark(SystemObject obj)
        {
            if (obj == null || obj.IsMarked)
            {
                return;
            }

            obj.IsMarked = true;

            Numbers list = obj as Numbers;
            if (list != null)
            {
                Mark(list.Head);
                Mark(list.Tail);
            }
        }

        public void CollectGarbage()
        {
            // Step 1. Mark
            foreach (var item in stack)
            {
                Mark(item);
            }

            // Step 2. Compact
            var ptr = allrefs.First;
            while (ptr != null)
            {
                if (!ptr.Value.IsMarked)
                {
                    var toRemove = ptr;
                    ptr = ptr.Next;
                    allrefs.Remove(toRemove);
                }
                else
                {
                    ptr.Value.IsMarked = false;
                    ptr = ptr.Next;
                }
            }
        }
    }
}
