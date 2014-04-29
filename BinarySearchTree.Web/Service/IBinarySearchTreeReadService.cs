using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using BinarySearchTree.Web.Controllers.api;
using BinarySearchTree.Web.DbContext;
using BinarySearchTree.Web.Models.Query;
using Microsoft.Ajax.Utilities;

namespace BinarySearchTree.Web.Service
{
    public interface IBinarySearchTreeReadService
    {
        BinarySearchTreeNodeQuery GetBinarySearchTreeNode(Guid id);
        BinarySearchTreeNodeQuery GetBinarySearchTreeRood();
    }

    public class BinarySearchTreeReadService : IBinarySearchTreeReadService
    {
        private readonly IBinarySearchTreeReadContext _context;

        public BinarySearchTreeReadService(IBinarySearchTreeReadContext context)
        {
            _context = context;
        }

        public BinarySearchTreeNodeQuery GetBinarySearchTreeNode(Guid id)
        {
            return _context.BinarySearchTreeNodeQueries.FirstOrDefault(x => x.Id == id);
        }

        public BinarySearchTreeNodeQuery GetBinarySearchTreeRood()
        {
            return _context.BinarySearchTreeNodeQueries.FirstOrDefault(x => x.ParentId == null);
        }
    }

    public class BinarySearchTreeReadServiceFake : IBinarySearchTreeReadService
    {
        private readonly IList<BinarySearchTreeNodeQuery> _nodes;
        /*
         *              10
         *             /  \
         *            5    15
         *           / \     \
         *          3   9     21 
         * 
         */

        public BinarySearchTreeReadServiceFake()
        {
            _nodes = new List<BinarySearchTreeNodeQuery>
            {
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000001"), LeftId = new Guid("00000000-0000-0000-0000-000000000002"), RightId = new Guid("00000000-0000-0000-0000-000000000003"), ParentId = null, Value = 10},
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000002"), LeftId = new Guid("00000000-0000-0000-0000-000000000004"), RightId = new Guid("00000000-0000-0000-0000-000000000005"), ParentId = new Guid("00000000-0000-0000-0000-000000000001"), Value = 5},
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000003"), LeftId = null, RightId = new Guid("00000000-0000-0000-0000-000000000006"), ParentId = new Guid("00000000-0000-0000-0000-000000000001"), Value = 15},
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000004"), LeftId = null, RightId = null, ParentId = new Guid("00000000-0000-0000-0000-000000000002"), Value = 3},
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000005"), LeftId = null, RightId = null, ParentId = new Guid("00000000-0000-0000-0000-000000000002"), Value = 9},
                new BinarySearchTreeNodeQuery() {Id = new Guid("00000000-0000-0000-0000-000000000006"), LeftId = null, RightId = null, ParentId = new Guid("00000000-0000-0000-0000-000000000003"), Value = 21}
            };
        }

        public BinarySearchTreeNodeQuery GetBinarySearchTreeNode(Guid id)
        {
            return _nodes.SingleOrDefault(x => x.Id == id);
        }


        public BinarySearchTreeNodeQuery GetBinarySearchTreeRood()
        {
            return _nodes.FirstOrDefault(x => x.ParentId == null);
        }
    }


}