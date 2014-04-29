using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataStructures
{
    public class FlattenByRow
    {

        public INode Flatten(INode head, INode tail)
        {
            INode result = head;
            if (head.Child != null)
            {
                tail.SetNextNode(head.Child);
                while (tail.GetNext() != null)
                {
                    tail = tail.GetNext();
                }
                head = head.GetNext();
            }

            while (head.GetNext() != null)
            {
                result.SetNextNode(head.GetNext());
                result = result.GetNext();
                if (head.Child != null)
                {
                    tail.SetNextNode(head.Child);
                    while (tail.GetNext() != null)
                    {
                        tail = tail.GetNext();
                    }
                }
                head = head.GetNext();
            }

            return result;
        }


        public INode UnFlatten(INode node)
        {

            if (node.Child != null)
            {
                node.Child.SetPrevious(null);
                node.Child = (UnFlatten(node.Child));
            }

            while (node.GetNext() != null)
            {
                node.SetNextNode(UnFlatten(node.GetNext()));
            }

            return node;

        }
    }
}
