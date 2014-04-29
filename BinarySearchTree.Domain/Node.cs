using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Domain
{
    public class Node
    {
        public Node()
        {
        }

        public Node(int value, Node parent)
        {
            Parent = parent;
            Value = value;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public virtual Node Parent { get; set; }
        public virtual Node LeftChild { get; set; }
        public virtual Node RightChild { get; set; }
        public int Value { get; set; }


        public void SetRightChild(Node root)
        {
            RightChild = root;
        }

        public void SetLeftChild(Node root)
        {
            LeftChild = root;            
        }
    }
}
