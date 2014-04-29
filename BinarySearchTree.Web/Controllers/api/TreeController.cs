using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BinarySearchTree.Domain;
using BinarySearchTree.Domain.Factory;
using BinarySearchTree.Web.Command;
using NextDimension.GenericRepository;

namespace BinarySearchTree.Web.Controllers.api
{
    public class TreeController : ApiController
    {
        private readonly IGenericRepository<ITree, Guid> _treeRepo;
        private readonly ITreeFactory _treeFactory;

        public TreeController(IGenericRepository<ITree, Guid> treeRepo, ITreeFactory treeFactory)
        {
            _treeRepo = treeRepo;
            _treeFactory = treeFactory;
        }

        public IEnumerable<string> Get()
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
        }

        public string Get(int id)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
        }

        [ActionName("PlantTree")]
        public void PlantTree(PlantTreeCommand cmd)
        {
            var tree = _treeFactory.PlantTree(cmd.Value);
            _treeRepo.Insert(tree);
            _treeRepo.Flush();
        }

        [ActionName("AddLeaf")]
        public void AddLeaf(AddLeafCommand cmd)
        {
            var persistedTree = _treeRepo.GetById(cmd.TreeId);
            if(persistedTree == null) throw new ObjectNotFoundException();
            persistedTree.AddLeaf(cmd.Value);
            _treeRepo.Flush();
        }
        
    }
}
