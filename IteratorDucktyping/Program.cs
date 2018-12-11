﻿using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace IteratorDucktyping
{
    public class Node<T>
    {
        public T value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            this.value = value;
        }

        public Node(T value, Node<T> left, Node<T> right) : this(value)
        {
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }
    }

    public class InOrderIterator<T>
    {
        public Node<T> Current { get; set; }
        public readonly Node<T> root;
        private bool yieldedStart;


        public InOrderIterator(Node<T> root)
        {
            this.root = root;
            Current = root;
            while (Current.Left != null)
                Current = Current.Left;

            //   1  <- root
            //  / \
            // 2   3
            // ^ Current
        }

        public bool MoveNext()
        {
            if (!yieldedStart)
            {
                yieldedStart = true;
                return true;
            }

            if (Current.Right != null)
            {
                Current = Current.Right;
                while (Current.Left != null)
                    Current = Current.Left;
                return true;
            }
            else
            {
                var p = Current.Parent;
                while (p != null && Current == p.Right)
                {
                    Current = p;
                    p = p.Parent;
                }
                Current = p;
                return Current != null;
            }
        }

        public void Reset()
        {
            Current = root;
            yieldedStart = false;
        }
    }

    public class BinaryTree<T>
    {
        private Node<T> root;

        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public InOrderIterator<T> GetEnumerator()
        {
            return new InOrderIterator<T>(root);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //   1
            //  / \
            // 2   3

            //in-order: 213
            //

            var root = new Node<int>(1,
                new Node<int>(2), new Node<int>(3));


            var tree = new BinaryTree<int>(root);
            foreach (var node in tree)
                WriteLine(node.value);

            ReadKey();
        }
    }
}
