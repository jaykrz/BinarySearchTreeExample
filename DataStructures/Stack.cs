using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Stack : IStack
    {
        private INode _node;

        public Stack(int value)
        {
            _node = new Node(value); 
        }

        public void Push(int value)
        {
            if (_node == null)
            {
                _node = new Node(value);
            }
            else
            {
                var newNode = new Node(value);
                newNode.SetNextNode(_node);
                _node = newNode;                
            }
        }

        public int Pop()
        {
            if(_node == null) throw new InvalidOperationException("stack empty you aint getting any vals outta it");

            if (_node.GetNext() == null)
            {
                var r = _node.Value;
                _node = null;
                return r;
            }

            var result = _node.Value;
            _node = _node.GetNext();
            return result;
        }
    }

    public interface IStack
    {
        void Push(int value);
        int Pop();
    }
}
