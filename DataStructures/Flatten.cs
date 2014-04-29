using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RecursiveFlatten : IFlatten
    {
        public INode Flatten(INode current)
        {
            if (current == null) return null;
            Console.WriteLine(current.Value);

            if (current.GetNext() == null && current.Child == null)
            {
                current.SetNextNode(current);
                current = current.GetNext();
                return current;
            }

            if (current.GetNext() != null)
            {
                current.SetNextNode(Flatten(current.GetNext()));
                current = current.GetNext();
                while (current.GetNext() != null)
                {
                    current = current.GetNext();
                }
                return current;
            }

            //if (current.Child != null)
            //{
                current.SetNextNode(Flatten(current.Child));
                current = current.GetNext();
                while (current.GetNext() != null)
                {
                    current = current.GetNext();
                }
                return current;
            //}

            //var item = Flatten(current.GetNext());
            //item.SetNextNode(Flatten(current.Child));
            //return item;

        }

        //public static INode Flatten(INode current)
        //{
        //    if (current == null) return null;
        //    Console.WriteLine(current.Value);


        //    if (current.GetNext() == null && current.Child == null)
        //    {
        //        return current;
        //    }

        //    if (current.GetNext() != null && current.Child == null)
        //    {
        //        current.SetNextNode(Flatten(current.GetNext()));
        //        current = current.GetNext();
        //        return current;
        //    }

        //    if (current.Child != null && current.GetNext() == null)
        //    {
        //        current.SetNextNode(Flatten(current.Child));
        //        current = current.GetNext();
        //        return current.GetNext();
        //    }

        //    //var temp = current;
        //    var next = Flatten(current.GetNext());
        //    var child = Flatten(current.Child);
            
            
        //    current.SetNextNode(next);
        //    while (current.GetNext() != null)
        //    {
        //        current = current.GetNext();
        //    }

        //    if(child != null) current.SetNextNode(child);
        //    //temp = temp.GetNext();
        //    return current;

        //}



        //public static INode Flatten(INode current)
        //{
        //    if (current == null) return null;
        //    Console.WriteLine(current.Value);

        //    if (current.GetNext() == null && current.Child == null)
        //    {
        //        current.SetNextNode(current);
        //        return current;
        //    }

        //    if (current.GetNext() != null && current.Child == null)
        //    {
        //        return Flatten(current.GetNext());
        //    }

        //    if (current.GetNext() == null && current.Child != null)
        //    {
        //        return Flatten(current.Child);
        //    }

        //    var item = Flatten(current.GetNext());
        //    item.SetNextNode(Flatten(current.Child));
        //    return item;

        //}

    }
}
