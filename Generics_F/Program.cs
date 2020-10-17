using System;

namespace Generics
{
    class Program
    {
        // uogólnienia są zamykane w czasie kompilacji
        static void Main(string[] args)
        {
            var stack = new Stack<MyCustomBaseModel>(); // typ dookreślony/zamknięty
            stack.Push(new MyCustomBaseModel());
            stack.Push(new MyCustomBaseModel());

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());



            DicEntry<string, int> Dic1 = new DicEntry<string, int>("First", 1); // konkretyzacja typu 
            DicEntry<string, int> Dic2 = new DicEntry<string, int>("Second", 2);
            Swap(ref Dic1, ref Dic2);



            var s1 = new StaticDataHolder<int>();
            var s2 = new StaticDataHolder<string>();
            var s3 = new StaticDataHolder<object>();

            Console.WriteLine(StaticDataHolder<int>.Counter++);
            Console.WriteLine(StaticDataHolder<int>.Counter++);
            Console.WriteLine(StaticDataHolder<string>.Counter++);
            Console.WriteLine(StaticDataHolder<object>.Counter++);


            Console.ReadKey();
        }

        // klasa uogólniona
        public class Stack<T>
            // typ niedookreślony/otwarty
        {
            private int position;
            T[] data = new T[100];

            public void Push(T obj)
            {
                data[position++] = obj;
            }

            public T Pop() => data[--position];
        }


        // metoda uogólniona
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public class MyCustomBaseModel
    {
    }

    // typ uogólniony
    // ograniczenia where T : xxx
    // https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    // https://www.tutlane.com/tutorial/csharp/csharp-generic-constraints
    public class DicEntry<TKey, TValue> 
    // ograniczenia uogólnień
        where TKey : class
        where TValue : struct
    {
        public DicEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }


    public class StaticDataHolder<T>
    {
        public static int Counter { get; set; } = 1;
    }


    // TODO:
    // Features of RecentlyUsedList:
    //
    // * It can hold objects of any class. (Use generics)
    // * It doesn't contain any duplicates.
    // * The newest elements are at the beginning of the list.
    // * If we insert a duplicate it is moved to the beginning of the list.
    // * It has constant size declared in constructor.If we add more elements than the size, the oldest element is removed.
    //
    // * Implement an Iterator for Recently Used List class
}