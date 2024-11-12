using System;
using System.Collections;
using System.Collections.Generic;

namespace WDBagProject
{
    // Class to represent an item with a unique ID
    public class BagItem<T>
    {
        public int ID { get; private set; }
        public T Item { get; private set; }

        public BagItem(int id, T item)
        {
            ID = id;
            Item = item;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Item: {Item}";
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        private int count = 0;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = Head;
            Head = newNode;
            count++;
        }

        public int Count => count;

        public IEnumerable<T> ToEnumerable()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    public class Bag<T>
    {
        private LinkedList<BagItem<T>> list;
        private int nextID = 1;

        public Bag()
        {
            list = new LinkedList<BagItem<T>>();
        }

        public void Add(T element)
        {
            list.Add(new BagItem<T>(nextID++, element));
        }

        public int Size()
        {
            return list.Count;
        }

        public IEnumerator<BagItem<T>> GetEnumerator()
        {
            return new BagIterator<T>(list);
        }

        private class BagIterator<U> : IEnumerator<BagItem<U>>
        {
            private List<BagItem<U>> items;
            private int currentIndex = -1;

            public BagIterator(LinkedList<BagItem<U>> list)
            {
                items = new List<BagItem<U>>(list.ToEnumerable());
                Shuffle(items);
            }

            public BagItem<U> Current => items[currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < items.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
                Shuffle(items);
            }

            public void Dispose() { }

            private void Shuffle(List<BagItem<U>> list)
            {
                Random random = new Random();
                for (int i = list.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    BagItem<U> temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Bag<string> bag = new Bag<string>();

            // Add random items with unique IDs to the bag
            string[] items = { "Marble", "Stone", "Shell", "Coin", "Key" };
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                string randomItem = items[random.Next(items.Length)];
                bag.Add(randomItem);
            }

            Console.WriteLine("Bag size: " + bag.Size());

            // Print elements in random order with their IDs
            foreach (var item in bag)
            {
                Console.WriteLine(item);
            }
        }
    }
}
