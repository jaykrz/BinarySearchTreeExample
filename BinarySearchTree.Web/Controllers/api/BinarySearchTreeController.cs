using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BinarySearchTree.Web.DbContext;
using BinarySearchTree.Web.Models.Query;
using BinarySearchTree.Web.Service;

namespace BinarySearchTree.Web.Controllers.api
{
    public class BinarySearchTreeController : ApiController
    {
        private readonly IBinarySearchTreeReadService _readService;

        public BinarySearchTreeController(IBinarySearchTreeReadService readService)
        {            
            _readService = readService;
        }

        public BinarySearchTreeNodeQuery Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return _readService.GetBinarySearchTreeRood();
            }
            return _readService.GetBinarySearchTreeNode(id);   
        }
    }
}
