using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinarySearchTree.Web.Models.Query
{
    public class BinarySearchTreeNodeQuery
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? LeftId { get; set; }
        public Guid? RightId { get; set; }
    }
}