using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree.Domain;
using BinarySearchTree.Domain.Factory;

namespace TestApp
{
    class Program
    {
        /*
 *              10
 *             /  \
 *            5    15
 *           / \     \
 *          3   9     21 
 * 
 */
        public static void Main(string[] args)
        {

            var tree = new TreeFactory().PlantTree(10);
            tree.AddLeaf(5);
            tree.AddLeaf(15);
            tree.AddLeaf(3);
            tree.AddLeaf(9);
            tree.AddLeaf(21);
            tree.AddLeaf(6);


            Console.WriteLine(tree.Root.Value);
            Console.WriteLine(tree.Root.LeftChild.Value);
            Console.WriteLine(tree.Root.LeftChild.LeftChild.Value);
            Console.WriteLine(tree.Root.LeftChild.RightChild.Value);
            Console.WriteLine(tree.Root.RightChild.Value);
            Console.WriteLine(tree.Root.RightChild.RightChild.Value);
            Console.WriteLine(tree.Root.LeftChild.RightChild.LeftChild.Value);
        }
    }
}
