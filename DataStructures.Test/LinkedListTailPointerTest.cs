using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test
{
    [TestClass]
    public class LinkedListTailPointerTest
    {

        [TestMethod]
        public void WhenInsertNodeAndKistEmpty_ExpectHeadSet()
        {
            var val = 21;
            ILinkedListTailPointer linkedListTail = new LinkedListTailPointer();
            linkedListTail.InsertAfter(null, val);
            Assert.AreEqual(val, linkedListTail.GetHead().Value);
        }

        [TestMethod]
        public void WhenInsertNodeAndListEmpty_ExpectTailSet()
        {
            var val = 21;
            ILinkedListTailPointer linkedListTail = new LinkedListTailPointer();
            linkedListTail. InsertAfter(null, val);
            Assert.AreEqual(val, linkedListTail.GetTail().Value);
        }


        [TestMethod]
        public void WhenInsertAfterHasNullElement_ExpectInsertOnHead()
        {
            ILinkedListTailPointer linkedListTail = new LinkedListTailPointer();
            
            linkedListTail.InsertAfter(null, 21);

        }

    }
}
