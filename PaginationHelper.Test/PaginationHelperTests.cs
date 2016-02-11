using NUnit.Framework;

namespace PaginationHelper.Test
{
    [TestFixture]
    public class PaginationHelperTests
    {
        private PaginationHelper _phelper;

        [SetUp]
        public void SetUp()
        {
            _phelper = new PaginationHelper(new[] { "a", "b", "c", "d", "e", "f" }, 4);
        }

        [Test]
        public void ReturnPageCount()
        {
            Assert.AreEqual(2, _phelper.PageCount());
        }

        [Test]
        public void ItemCount()
        {
            var arr = new[] {"a", "b" };
            var ph = new PaginationHelper(arr, 1);
            Assert.AreEqual(arr.Length, ph.ItemCount());
        }

        [Test]
        public void PageItemCount()
        {
            Assert.AreEqual(4, _phelper.PageItemCount(0));
        }

        [Test]
        public void TakeSecondPageItems()
        {
            Assert.AreEqual(2, _phelper.PageItemCount(1));
        }

        [Test]
        public void TakeNonexistpage()
        {
            Assert.AreEqual(-1, _phelper.PageItemCount(2));
        }

        [Test]
        public void ElementOnSeconPage()
        {
            Assert.AreEqual(1, _phelper.PageIndex(5));
        }

        [Test]
        public void ElementOnFirstPage()
        {
            Assert.AreEqual(0, _phelper.PageIndex(2));
        }

        [Test]
        public void ElementOnNonExistPage()
        {
            Assert.AreEqual(-1, _phelper.PageIndex(20));
        }

        [Test]
        public void ElementOnPageWithNegativeIndex()
        {
            Assert.AreEqual(-1, _phelper.PageIndex(-10));
        }
    }
}