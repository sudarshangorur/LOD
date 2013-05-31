using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public static class SortData
    {
        public static int[] SortArrayDescending(IEnumerable<int> arrayToSort)
        {
            var sortedArray = arrayToSort.OrderByDescending(c => c).ToArray();
            return sortedArray;
        }

        public static int[] SortArrayAscending(IEnumerable<int> arrayToSort)
        {
            var sortedArray = arrayToSort.OrderByDescending(c => c).Reverse().ToArray();
            return sortedArray;
        }


    }
}
