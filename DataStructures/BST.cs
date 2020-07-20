using System;
using System.Collections.Generic;

namespace DataStructures
{
    class BST
    {

        private Node root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private Node Insert(Node root, int value)
        {
            if (root == null)
                return new Node(value);

            if (value < root.value)
                root.leftChild = Insert(root.leftChild, value);
            else if (value > root.value)
                root.rightChild = Insert(root.rightChild, value);
            else
                throw new InvalidOperationException("Can't Insert Duplicate values.");
            return root;
        }

        public bool Find(int value)
        {
            return Find(root, value) != null;
        }

        private Node Find(Node root, int value)
        {
            if (root == null)
                return null;

            if (value == root.value)
                return root;

            if (value < root.value)
                return Find(root.leftChild, value);
            else
                return Find(root.rightChild, value);
        }

        public void Delete(int value)
        {
            if (root == null)
                throw new InvalidOperationException("Tree is Empty.");
            root = Delete(root, value);
        }

        private Node Delete(Node root, int value)
        {
            if (root == null)
                throw new InvalidOperationException("Node not Found!!.");

            if (root.value == value)
            {
                if (root.leftChild == null && root.rightChild == null)
                    root = null;
                else if (root.leftChild == null)
                    root = root.rightChild;
                else if (root.rightChild == null)
                    root = root.leftChild;
                else
                {
                    var left = root.leftChild;
                    root = root.rightChild;
                    var temp = root;
                    while (temp.leftChild != null)
                    {
                        temp = temp.leftChild;
                    }
                    temp.leftChild = left;
                }
            }
            else if (value < root.value)
                root.leftChild = Delete(root.leftChild, value);
            else
                root.rightChild = Delete(root.rightChild, value);
            return root;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;
            return Math.Max(Height(root.leftChild), Height(root.rightChild)) + 1;
        }

        public List<int> NodesAtLevel(int level)
        {
            var list = new List<int>();
            NodesAtLevel(root, level, list);
            return list;
        }

        private void NodesAtLevel(Node root, int level, List<int> list)
        {
            if (root == null)
                return;

            if (level == 0)
            {
                list.Add(root.value);
                return;
            }
            NodesAtLevel(root.leftChild, level - 1, list);
            NodesAtLevel(root.rightChild, level - 1, list);
        }

        public List<int> InorderTraversal()
        {
            var list = new List<int>();
            InorderTraversal(root, list);
            return list;
        }

        private void InorderTraversal(Node root, List<int> list)
        {
            if (root == null)
            {
                return;
            }
            InorderTraversal(root.leftChild, list);
            list.Add(root.value);
            InorderTraversal(root.rightChild, list);
        }

        public List<int> PreorderTraversal()
        {
            var list = new List<int>();
            PreorderTraversal(root, list);
            return list;
        }

        private void PreorderTraversal(Node root, List<int> list)
        {
            if (root == null)
            {
                return;
            }
            list.Add(root.value);
            PreorderTraversal(root.leftChild, list);
            PreorderTraversal(root.rightChild, list);
        }

        public List<int> PostorderTraversal()
        {
            var list = new List<int>();
            PostorderTraversal(root, list);
            return list;
        }

        private void PostorderTraversal(Node root, List<int> list)
        {
            if (root == null)
            {
                return;
            }
            PostorderTraversal(root.leftChild, list);
            PostorderTraversal(root.rightChild, list);
            list.Add(root.value);
        }

        public List<int> LevelOrderTraversal()
        {
            var list = new List<int>();
            for (var i = 0; i <= Height(); i++)
            {
                list.AddRange(NodesAtLevel(i));
            }
            return list;
        }

        public List<List<int>> LevelOrderTraversalList()
        {
            var list = new List<List<int>>();
            for (var i = 0; i <= Height(); i++)
            {
                list.Add(NodesAtLevel(i));
            }
            return list;
        }

        private class Node
        {
            public int value { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }

            public Node(int value)
            {
                this.value = value;
            }

            public override string ToString()
            {
                return $"Node = {value}";
            }
        }
    }
}

//
//var tree = new BST();
//tree.Insert(7);
//            tree.Insert(10);
//            tree.Insert(12);
//            tree.Insert(9);
//            tree.Insert(3);
//            tree.Insert(5);
//            tree.Insert(1);
//            Display(tree.InorderTraversal());
//Console.WriteLine(tree.Height());

//            Console.WriteLine(tree.Find(10));
//            Console.WriteLine(tree.Find(100));

//            tree.Delete(1);
//            Display(tree.InorderTraversal());
//Console.WriteLine(tree.Height());
//            tree.Delete(7);
//            Display(tree.InorderTraversal());
//Console.WriteLine(tree.Height());

//            Display(tree.NodesAtLevel(1));
//            Display(tree.NodesAtLevel(4));

//            Display(tree.LevelOrderTraversal());
