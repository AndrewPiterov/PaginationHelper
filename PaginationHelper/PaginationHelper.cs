using System;
using System.Collections.Generic;
using System.Linq;

namespace PaginationHelper
{
    public class PaginationHelper
    {
        private readonly string[] _array;
        private readonly int _perPage;

        public PaginationHelper(IEnumerable<string> array, int perPaage)
        {
            _array = array.ToArray();
            _perPage = perPaage;
        }

        /// <summary>
        /// количество элементов
        /// </summary>
        /// <returns></returns>
        public int PageCount() => (int)Math.Ceiling((decimal)_array.Length / _perPage);

        /// <summary>
        /// количество страниц
        /// </summary>
        /// <returns></returns>
        public int ItemCount() => _array.Length;

        /// <summary>
        /// количество элементов на странице с указанным номером
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public int PageItemCount(int pageNumber) =>
            IsPageExist(pageNumber) ? _array.Skip(pageNumber * _perPage).Take(_perPage).Count() : -1;

        /// <summary>
        /// номер страницы, на которой находится элемент с указанным номером
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > ItemCount())
                return -1;

            var full = itemIndex / _perPage;
            var rem = itemIndex % _perPage;

            if (rem > 0)
                return full;

            return full - 1;
        }


        private bool IsPageExist(int pageNumber) => PageCount() - 1 >= pageNumber;
    }
}
