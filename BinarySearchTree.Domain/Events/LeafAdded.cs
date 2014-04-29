using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Domain.Events
{
    public class LeafAdded
    {
        public int Value { get; set; }

        public LeafAdded(int value)
        {
            Value = value;
        }
    }
}

