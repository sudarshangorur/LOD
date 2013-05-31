using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Specs.Helpers
{
    static class ArrayConverter
    {
        public static IEnumerable<int> StringToIntList(string str)
        {
            return (str ?? "").Split(',').Select<string, int>(int.Parse);
        }
    }
}
