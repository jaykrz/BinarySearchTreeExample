using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node : INode
    {
        public Node(int value)
        {
            Value = value;
        }

        public void SetNextNode(INode nextNode)
        {

            if (_nextNode == null)
            {
                _nextNode = nextNode;
                nextNode.SetPrevious(this);


            }
        }

        private INode _nextNode { get; set; }
        private INode _previousNode { get; set; }
        public int Value { get; set; }
        public INode Child { get; set; }


        public INode GetPrevious()
        {
            return _previousNode;
        }

        public INode GetNext()
        {
            return _nextNode;
        }

        public void SetPrevious(Node node)
        {
            if (_previousNode == null)
            {
                _previousNode = node;
                _previousNode.SetNextNode(this);
            }
        }
    }

    public interface INode
    {
        //INode NextNode { get; set; }
        int Value { get; set; }

        INode Child { get; set; }
        void SetNextNode(INode nextNode);
        INode GetPrevious();
        INode GetNext();

        void SetPrevious(Node node);
    }
}
