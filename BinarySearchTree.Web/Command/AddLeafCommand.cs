using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinarySearchTree.Web.Command
{
    public class AddLeafCommand
    {
        public Guid TreeId { get; set; }
        public int Value { get; set; }

    }
}