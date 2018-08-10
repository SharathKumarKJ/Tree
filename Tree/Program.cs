using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.AddNewNode(10);
            tree.AddNewNode(20);
            tree.AddNewNode(30);
            tree.AddNewNode(40);
            tree.AddNewNode(50);
            tree.AddNewNode(60);
            tree.AddNewNode(70);
           
            Console.WriteLine("Pre Order Recursive Display");
            tree.DisplayPreOrderRecursive(tree.Root);
            Console.WriteLine("\n\nIn Order Recursive Display");
            tree.DisplayInOrderRecursive(tree.Root);
            Console.WriteLine("\n\nPost Order Recursive Display");
            tree.DisplayPostOrderRecursive(tree.Root);
            Console.WriteLine("\n\nLevel Order Display");
            tree.LevelOrderDisplay(tree.Root);
            Console.WriteLine("\n\nPre Order Display");
            tree.DisplayPreOrder(tree.Root);
            Console.WriteLine("\n\nIn Order Display");
            tree.DisplayInOrder(tree.Root);

            // Console.WriteLine("\n\nPost Order Display");
            //tree.DisplayPostOrder(tree.Root);

            Console.WriteLine("\n\nMax Element in a tree Recursive ");
            var max = tree.FindMaxRecursive(tree.Root);
            Console.WriteLine("Max : " + max);
            Console.WriteLine("\n\nMax Element in a tree ");
            max = tree.FindMax(tree.Root);
            Console.WriteLine("Max : " + max);
            Console.WriteLine("\n\nSize of the tree By Recursive Method  ");
            int size = tree.SizeOfBinaryTreeRecursive(tree.Root);
            Console.WriteLine("Size :" + size);
            Console.WriteLine("\n\nSize of the tree");
            size = tree.SizeOfBinaryTree(tree.Root);
            Console.WriteLine("Size :" + size);


            Console.WriteLine("\n\nLevel Order Reverse Order");
            tree.LevelOrderReverseDisplay(tree.Root);

            Console.WriteLine("\n\nHeight of the tree");
            int height = tree.FindHeightOftheBinaryTree(tree.Root);
            Console.WriteLine("Height : " + height);

            Console.WriteLine("\n\nNormal Funcation to  find Height of the tree");
             height = tree.FindHeightOftheBinaryTreeNormal(tree.Root);
            Console.WriteLine("Height : " + height);

            Console.WriteLine("\n\nDeepest Node");
            var deepest = tree.DeepestNode(tree.Root);
            Console.WriteLine("Deepest : " + deepest.Data);

            Console.WriteLine("Delete the Node in tree");
            tree.DeleteNode(tree.Root, 10);
            tree.DisplayPreOrderRecursive(tree.Root);

            Console.ReadLine();
        }
    }
    class Node<T>  where T : struct
    {
        private T _data;

        public T Data { get => _data; set => _data = value; }

        public Node<T> Left;

        public Node<T> Right;

       
    }

    class Tree<T> where T : struct
    {

        public Node<T> Root;

        public void AddNewNode(T data)
        {
            var newNode = new Node<T>
            {
                Data = data,
                Left = null,
                Right = null
            };


            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(Root);

            while (queue.Any())
            {
                var temp = queue.Dequeue();

                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }
                else
                {
                    temp.Left = newNode;
                    queue = new Queue<Node<T>>();
                    break;
                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
                else
                {
                    temp.Right = newNode;
                    queue = new Queue<Node<T>>();
                    break;
                }


            }

        }

        public void DisplayPreOrderRecursive(Node<T> root)
        {
            if (root == null) return;

            Console.Write(root.Data + " ");
            DisplayPreOrderRecursive(root.Left);
            DisplayPreOrderRecursive(root.Right);
        }

        public void DisplayInOrderRecursive(Node<T> root)
        {
            if (root == null) return;
            DisplayInOrderRecursive(root.Left);
            Console.Write(root.Data + " ");
            DisplayInOrderRecursive(root.Right);
        }

        public void DisplayPostOrderRecursive(Node<T> root)
        {
            if (root == null) return;
            DisplayPostOrderRecursive(root.Left);
            DisplayPostOrderRecursive(root.Right);
            Console.Write(root.Data + " ");
        }

        public void LevelOrderDisplay(Node<T> root)
        {
            if (root == null) return;

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue != null && queue.Any())
            {
                var temp = queue.Dequeue();
                Console.Write(temp.Data + " ");

                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }

            }

        }

        public void DisplayPreOrder(Node<T> root)
        {
            if (root == null) return;

            Stack<Node<T>> stack = new Stack<Node<T>>();

            stack.Push(root);

            while (stack.Any())
            {
                var temp = stack.Pop();

                Console.Write(temp.Data + " ");

                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack.Push(temp.Left);
                }
            }

        }

        public void DisplayInOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            Stack<Node<T>> stack = new Stack<Node<T>>();

            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                if (!stack.Any()) break;
                root = stack.Pop();
                Console.Write(root.Data + " ");
                root = root.Right;
            }
        }

        public void DisplayPostOrder(Node<T> root)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();

            while (true)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                else
                {
                    if (!stack.Any()) return;
                    else if (stack.Peek().Right == null)
                    {
                        root = stack.Pop();
                        Console.Write(root.Data + " ");
                        if (root == stack.Peek().Right)
                        {
                            Console.Write(stack.Peek().Data + " ");
                            stack.Pop();
                        }
                        if (Root == stack.Peek())
                        {
                            Console.Write(stack.Peek().Data + " ");
                            stack.Pop();
                        }
                    }
                    if (stack.Any())
                    {
                        root = stack.Peek().Right;
                    }
                    else
                    {
                        root = null;
                    }
                }
            }

        }

        public int FindMaxRecursive(Node<T> root)
        {
            int left;
            int right;
            int rootValue;
            int max = 0;
            if (root != null)
            {
                rootValue = Convert.ToInt32(root.Data);
                left = FindMaxRecursive(root.Left);
                right = FindMaxRecursive(root.Right);
                if (left > right)
                {
                    max = left;
                }
                else
                {
                    max = right;
                }
                if (rootValue > max)
                {
                    max = rootValue;
                }
            }
            return max;

        }

        public int FindMax(Node<T> root)
        {
            if (root == null) return 0;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            int max = 0;
            while(queue.Any())
            {
                var temp = queue.Dequeue();
                var data = Convert.ToInt32(temp.Data);
                if (max < data)
                {
                    max = data;
                }
                if(temp.Left!=null)
                {
                    queue.Enqueue(temp.Left);
                }
                if(temp.Right!=null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
            return max;
        }

        public int SizeOfBinaryTreeRecursive(Node<T> root)
        {
            if (root == null) return 0;
            return (SizeOfBinaryTreeRecursive(root.Left) + 1 + SizeOfBinaryTreeRecursive(root.Right));
        }

        public int SizeOfBinaryTree(Node<T> root)
        {
            int count = 0;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while(queue.Any())
            {
                var temp = queue.Dequeue();

                count++;
                if(temp.Left!=null)
                {
                    queue.Enqueue(temp.Left);
                }
                if(temp.Right!=null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
            return count;
        }

        public void LevelOrderReverseDisplay(Node<T> root)
        {
            if (root == null) return;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            Stack<int> stack = new Stack<int>();
            queue.Enqueue(root);

            while (queue != null && queue.Any())
            {
                var temp = queue.Dequeue();

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }
                stack.Push(Convert.ToInt32(temp.Data));
            }
            while(stack.Any())
            {
                Console.Write(stack.Pop() + " ");
            }
        }

        public int FindHeightOftheBinaryTree(Node<T> root)
        {
            int left, right;
            if (root == null) return 0; 
            left = FindHeightOftheBinaryTree(root.Left);
            right = FindHeightOftheBinaryTree(root.Right);

            if (left > right)
                return left + 1;
            return right + 1;
        }

        public int FindHeightOftheBinaryTreeNormal(Node<T> root)
         {
            if (root == null) return 0;

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);
            queue.Enqueue(null);
            int level = 0;
            while(queue.Any())
            {
                var temp = queue.Dequeue();

                if (temp == null)
                {
                    if (queue.Any())
                        queue.Enqueue(null);
                    level++;
                }
                else
                {
                    if (temp.Left != null)
                    {
                        queue.Enqueue(temp.Left);
                    }
                    if (temp.Right != null)
                    {
                        queue.Enqueue(temp.Right);
                    }
                }
            }
            return level;

        }

        public Node<T> DeepestNode(Node<T> root)
        {
            if (root == null) return null;
            var temp = new Node<T>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            while(queue.Any())
            {
                temp = queue.Dequeue();
                if(temp.Left!=null)
                {
                    queue.Enqueue(temp.Left);
                }
                if(temp.Right!=null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
            return temp;
        }

        public void DeleteNode(Node<T> root, int data)
        {
            if (root == null) return;
            var node = DeepestNode(root);

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while(queue.Any())
            {
                var temp = queue.Dequeue();
                if(Convert.ToInt32(temp.Data) == data)
                {
                    temp.Data = node.Data;
                    node.Data = default(T);
                    node = null;
                    queue = new Queue<Node<T>>();
                    return;
                }
                if(temp.Left!=null)
                {
                    queue.Enqueue(temp.Left);
                }
                if(temp.Right!=null)
                {
                    queue.Enqueue(temp.Right);
                }

            }
        }

    }
}