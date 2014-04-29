using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree.Domain.Events;
using CommonDomain.Core;

namespace BinarySearchTree.Domain
{
    public class Tree : AggregateBase, ITree
    {
        public Tree()
        {
        }

        public Tree(Guid id, int val)
        {
            RaiseEvent(new TreePlanted(id, val));
        }

        public virtual Node Root { get; set; }

        public void AddLeaf(int value)
        {
            RaiseEvent(new LeafAdded(value));
        }

        private void ResetRootNode()
        {
            while (Root.Parent != null)
            {
                Root = Root.Parent;
            }
        }

        #region Events Handlers
        public void Apply(TreePlanted evnt)
        {
            Id = evnt.Id;
            Root = new Node(evnt.Value, null);
        }

        public void Apply(LeafAdded evnt)
        {
            var value = evnt.Value;
            Node parent = null;

            while (Root != null)
            {
                parent = Root;
                if (value < Root.Value)
                {
                    Root = Root.LeftChild;
                }
                else
                {
                    Root = Root.RightChild;
                }
            }

            var newNode = new Node(value, parent);
            Root = newNode;

            if (parent != null && value > parent.Value)
            {
                parent.SetRightChild(newNode);
            }
            else if (parent != null && value < parent.Value)
            {
                parent.SetLeftChild(newNode);
            }

            ResetRootNode();
        }
        #endregion
    }
}
