using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Domain
{
    public interface ITree
    {
        Node Root { get; set; }
        void AddLeaf(int value);
    }
}
