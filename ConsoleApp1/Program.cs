using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void electionWinner()
        {
            string[] votes = { "10", "Alex", "Michael", "Harry", "Dave", "Michael", "Victor", "Harry", "Alex", "Mary", "Mary" };

            Dictionary<string, int> voterCount = new Dictionary<string, int>();

            for (int i = 0; i < votes.Length; i++)
            {
                int count = 0;

                if (!voterCount.ContainsKey(votes[i]))
                {
                    foreach (string vote in votes)
                    {
                        if (vote.ToLower() == votes[i].ToLower())
                        {
                            count++;
                        }
                    }

                    voterCount.Add(votes[i], count);
                }
            }

            var sortedWinnter = voterCount.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            var winner = sortedWinnter.First();

            Console.WriteLine(winner);
            Console.ReadLine();
        }
    }

    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;

        public Node()
        {
        }

        public Node(T data) : this(data, null) { }

        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
            {
                if (node.Value.Equals(value))
                    return node;
            }

            // if we reached here, we didn't find a matching node
            return null;
        }
    }


    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base()
        {

        }
        public BinaryTreeNode(T data) : base(data, null)
        {

        }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;

            Neighbors = children;
        }


        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[1] = value;
            }
        }

    }
}
