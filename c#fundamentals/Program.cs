using System;
using System.Collections;

namespace c_fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array concepts
            string[] a = { "Hello", "world", "this", "my", "learning", "in", "array" };
            for (int i = 0; i < a.Length; i++) 
            {
                Console.WriteLine(a[i]);
            }
            //arrayList
            Console.WriteLine("ArrayList concepts:");
            ArrayList arrayList = new ArrayList();
            arrayList.Add("My");
            arrayList.Add("Name");
            arrayList.Add("is");
            arrayList.Add("Prakhar");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);

            }
            arrayList.Sort();
            Console.WriteLine("After Sorting");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            arrayList.Reverse();
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
