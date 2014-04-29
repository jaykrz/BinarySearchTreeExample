using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Domain.Factory
{
    public class TreeFactory : ITreeFactory
    {
        public Tree PlantTree(int value)
        {
            return new Tree(Guid.NewGuid(), value);
        }

    }

    public interface ITreeFactory
    {
        Tree PlantTree(int value);
    }
}
