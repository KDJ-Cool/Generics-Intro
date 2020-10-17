namespace Generics
{
    public class Stack<T>
    // typ niedookreślony/otwarty
    {
        private int position;
        T[] data = new T[100];

        public void Push(T obj)
        {
            data[position++] = obj;
        }

        public T Pop()
        {
            return data[--position];
        }
    }
}