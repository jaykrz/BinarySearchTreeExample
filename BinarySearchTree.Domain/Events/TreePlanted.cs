using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Domain.Events
{
    public class TreePlanted
    {
        public readonly Guid Id;
        public readonly int Value;

        public TreePlanted(Guid id, int value)
        {
            Id = id;
            Value = value;
        }
    }
}
