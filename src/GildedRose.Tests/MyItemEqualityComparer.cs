using GildedRose.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{

    public class MyItemEqualityComparer : IComparer, IComparer<Item>
    {
        public int Compare(object x, object y)
        {
            var lhs = x as Item;
            var rhs = y as Item;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public int Compare(Item x, Item y)
        {
            if (x == null || y == null) return -1;
            return x.Name == y.Name && x.SellIn == y.SellIn && x.Quality == y.Quality ? 0 : -1;
        }
    }
}
