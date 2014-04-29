using System;
using System.Data;
using BinarySearchTree.Domain;
using BinarySearchTree.Domain.Factory;
using BinarySearchTree.Web.Command;
using BinarySearchTree.Web.Controllers.api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NextDimension.GenericRepository;

namespace BinarySearchTree.Web.Test.Controllers
{
    [TestClass]
    public class TreeControllerTest
    {
        Mock<IGenericRepository<ITree, Guid>> _treeRepo;
        Mock<ITreeFactory> _treeFactory;

        [TestInitialize]
        public void Init()
        {
            _treeRepo  = new Mock<IGenericRepository<ITree, Guid>>();
            _treeFactory = new Mock<ITreeFactory>();
        }

        [TestMethod]
        public void WhenPlantTreeCommand_ExpectFactoryPlantTreeCalled()
        {
            var value = 123;
            var treeController = new TreeController(_treeRepo.Object, _treeFactory.Object);
            treeController.PlantTree(new PlantTreeCommand() { Value = value});;
            _treeFactory.Verify(x=>x.PlantTree(value));
        }
        
        
        [TestMethod]
        public void WhenPlantTreeCommand_ExpectRepositoryInsertCalled()
        {
            var value = 123;
            var tree = new Tree();
            var treeController = new TreeController(_treeRepo.Object, _treeFactory.Object);
            _treeFactory.Setup(x => x.PlantTree(value)).Returns(tree);
            treeController.PlantTree(new PlantTreeCommand() { Value = value }); ;
            _treeRepo.Verify(x=>x.Insert(tree));
        }

        [TestMethod]
        public void WhenAddLeafCommand_ExpectAddLeafCalledOnTree()
        {
            var value = 321;
            var tree = new Mock<ITree>();
            _treeRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(tree.Object);
            var treeController = new TreeController(_treeRepo.Object, _treeFactory.Object);
            treeController.AddLeaf(new AddLeafCommand() { Value = value, TreeId = It.IsAny<Guid>()});
            tree.Verify(x=>x.AddLeaf(value));
        }


        [TestMethod]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void WhenAddLeafCommandAndRepoDoesNotContainSpecifiedTree_ExpectException()
        {
            var value = 321;
            var treeController = new TreeController(_treeRepo.Object, _treeFactory.Object);
            treeController.AddLeaf(new AddLeafCommand() { Value = value, TreeId = It.IsAny<Guid>() });
        }
    }
}
