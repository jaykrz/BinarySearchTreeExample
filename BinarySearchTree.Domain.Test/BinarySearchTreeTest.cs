using System;
using BinarySearchTree.Domain.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BinarySearchTree.Domain.Test
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private Tree _tree;

        [TestInitialize]
        public void Init()
        {
            _tree = new TreeFactory().PlantTree(10);
            _tree.AddLeaf(5);
            _tree.AddLeaf(15);
            _tree.AddLeaf(3);
            _tree.AddLeaf(9);
            _tree.AddLeaf(21);
        }

        [TestMethod]
        public void VerifyTreeSetupCorrectly()
        {
            /*
             *              10
             *             /  \
             *            5    15
             *           / \     \
             *          3   9     21 
             * 
             */

            Assert.AreEqual(10, _tree.Root.Value);
            Assert.AreEqual(5, _tree.Root.LeftChild.Value);
            Assert.AreEqual(3, _tree.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(9, _tree.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(15, _tree.Root.RightChild.Value);
            Assert.AreEqual(21, _tree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void WhenAddNodeToBSTExpectRootReset()
        {
            Assert.IsNull(_tree.Root.Parent);
        }

        [TestMethod]
        public void WhenAddNoteToBSTExportNodeAddedToLeaf()
        {
            _tree.AddLeaf(6);
            Assert.IsNull(_tree.Root.LeftChild.RightChild.LeftChild.LeftChild);
            Assert.IsNull(_tree.Root.LeftChild.RightChild.LeftChild.RightChild);
        }

    }
}
