using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedListTailPointer : ILinkedListTailPointer
    {
        private INode _head;
        private INode _tail;

        public bool InsertAfter(INode node, int value)
        {
            if (node == null)
            {
                InsertAtHead(value);
                return true;
            }

            throw new NotImplementedException();

        }

        private void InsertAtHead(int value)
        {
            if(IsEmpty())
            {
                var node = new Node(value);
                _head = node;
                _tail = node;
            }
        }

        private bool IsEmpty()
        {
            if (_head == null && _tail == null) return true;
            
            if (_head != null && _tail != null) return false;

            throw new InvalidOperationException("list in invalid state");
        }

        public bool Delete(INode node)
        {
            throw new NotImplementedException();
        }


        public INode GetHead()
        {
            return _head;
        }

        public INode GetTail()
        {
            return _tail;
        }
    }

    public interface ILinkedListTailPointer
    {
        bool InsertAfter(INode node, int value);
        bool Delete(INode node);
        INode GetHead();
        INode GetTail();

    }
}
