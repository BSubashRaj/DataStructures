using System;
using System.Collections.Generic;

namespace DataStructures
{
    class AVL
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

            SetHeight(root);

            root = Balance(root);

            return root;
        }

        private Node Balance(Node root)
        {
            if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.rightChild) > 0)
                    root.rightChild = RightRotate(root.rightChild);
                root = LeftRotate(root);
            }
            else if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.leftChild) < 0)
                    root.leftChild = LeftRotate(root.leftChild);
                root = RightRotate(root);
            }
            return root;
        }

        private Node LeftRotate(Node root)
        {
            var newRoot = root.rightChild;

            root.rightChild = newRoot.leftChild;
            newRoot.leftChild = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }

        private Node RightRotate(Node root)
        {
            var newRoot = root.leftChild;

            root.leftChild = newRoot.rightChild;
            newRoot.rightChild = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }

        private void SetHeight(Node node)
        {
            if (node == null)
                return;
            node.height = Math.Max(Height(node.leftChild), Height(node.rightChild)) + 1;
        }

        private int Height(Node node)
        {
            return node == null ? -1 : node.height;
        }

        private int BalanceFactor(Node node)
        {
            return node == null ? 0 : Height(node.leftChild) - Height(node.rightChild);
        }

        private bool IsLeftHeavy(Node node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(Node node)
        {
            return BalanceFactor(node) < -1;
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

            SetHeight(root);

            root = Balance(root);

            return root;
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

        private class Node
        {
            public int value { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }
            public int height { get; set; }

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
//var tree = new AVL();
//tree.Insert(7);
//            tree.Insert(10);
//            tree.Insert(3);
//            tree.Insert(6);
//            tree.Insert(5);
//            Display(tree.InorderTraversal());
//tree.Delete(10);
//            Display(tree.InorderTraversal());
//tree.Delete(3);
//            Display(tree.InorderTraversal());
