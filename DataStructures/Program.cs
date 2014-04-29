using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        public static void Main(string[] args)
        {
            //RunStackTest();
            FlattenTest();
        }

        private static void RunStackTest()
        {
            Console.WriteLine("Start");
            Console.WriteLine("Push 1");
            var stack = new Stack(1);
            Console.WriteLine("Push 2");
            stack.Push(2);
            Console.WriteLine("Push 3");
            stack.Push(3);
            Console.WriteLine("Push 4");
            stack.Push(4);
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Pop ??????? expected Exception");

            try
            {
                stack.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);    
            }

            Console.WriteLine("Push 5 on Empty stack");
            stack.Push(5);

            Console.WriteLine("Pop " + stack.Pop());

        }

        public static void FlattenTest()
        {
            INode node = new Node(1);
            INode child2 = new Node(2);
            INode child3 = new Node(3);
            INode child7 = new Node(7);
            INode child10 = new Node(10);
            child10.Child = new Node(12);
            INode child11 = new Node(11);

            var node8 = new Node(8);
            var node9 = new Node(9);
            var node14 = new Node(14);
            node14.SetNextNode( new Node(15));
            node9.Child = node14;
            node9.SetNextNode(new Node(13));
            node8.SetNextNode(node9);
            child7.SetNextNode(node8);
            child7.Child = child10;
            INode node4 = new Node(4);
            node4.Child = child11;
            child3.SetNextNode(node4);
            child2.SetNextNode(new Node(5));
            child2.Child = child3;

            node.Child = child2;

            INode node6 = new Node(6);
            INode node16 = new Node(16);
            node6.SetNextNode(node16);
            node6.Child = child7;
            node.SetNextNode(node6);


           




            //var test = new RecursiveFlatten().Flatten(node);
            var test = new FlattenByRow().Flatten(node, node16);
            

            Console.WriteLine(test.Value);
            while(test.GetPrevious() != null)
            {
                Console.WriteLine(test.GetPrevious().Value);
                test = test.GetPrevious();
            }

            Console.WriteLine("------------------------------------");

            var test2 = new FlattenByRow().UnFlatten(test);
            while (test2.GetPrevious() != null)
            {
                Console.WriteLine(test2.GetPrevious().Value);
                test2 = test.GetPrevious();
            }


        }
    }
}
