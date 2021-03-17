using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class MyStack<T>
    {
        private T[] data;

        private int capacity;

        public MyStack()
            : this(4)
        {
        }

        public MyStack(int capacity)

        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }

        public int Count { get; private set; }



        public void Push(T element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }

            this.data[this.Count] = element;

            Count++;
        }

        private void Resize()
        {
            T[] newStack = new T[data.Length * 2];

            for (int i = 0; i < data.Length; i++)
            {
                newStack[i] = data[i];
            }

            data = newStack;
        }
        public T Peek()
        {
            this.ValidateStack();

            var result = this.data[this.Count - 1];

            return result;
        }

        public T Pop()
        {
            ValidateStack();

            var result = this.data[this.Count - 1];

            this.Count--;

            return result;

        }

        public void Foreach(Action<T> action)
        {
            for (int i = this.Count-1; i >=0; i--)
            {
                action(this.data[i]);
            }
        }


        public void Crear()
        {

            this.data = new T[this.capacity];

            this.Count = 0;
        }


        private void ValidateStack()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty");
            }
        }



    }
}
