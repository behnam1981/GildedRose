using GildedRose.Console;
using GildedRose.Console.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    [TestClass]
    public class TestAssemblyTests
    {

        MyItemEqualityComparer comparer = new MyItemEqualityComparer();

        [TestMethod]
        public void TestNormal()
        {
            var actual = new List<Item>() { new Item() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50 }, new Item() { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 38 } };
            var expected = new List<Item>() { new Item() { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 49 }, new Item() { Name = "Elixir of the Mongoose", SellIn = 9, Quality = 37 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void TestAgedBire()
        {
            var actual = new List<Item>() { new Item() { Name = "Aged Brie", SellIn = 2, Quality = 10 } };
            var expected = new List<Item>() { new Item() { Name = "Aged Brie", SellIn = 1, Quality = 11 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void TestBackstage()
        {
            var actual = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            var expected = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void TestBackstageTenDaysOrLess()
        {
            var actual = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 } };
            var expected = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 22 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void TestBackstageFiveDaysOrLess()
        {
            var actual = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 20 } };
            var expected = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 23 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void TestBackstageAfterConcert()
        {
            var actual = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var expected = new List<Item>() { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }


        [TestMethod]
        public void Sulfuras()
        {
            var actual = new List<Item>() { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var expected = new List<Item>() { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void Conjured()
        {
            var actual = new List<Item>() { new Item() { Name = "Conjured Mana Cake", SellIn = 12, Quality = 40 } };
            var expected = new List<Item>() { new Item() { Name = "Conjured Mana Cake", SellIn = 11, Quality = 38 } };

            var itemService = new ItemService(actual);
            itemService.UpdateQuality();


            CollectionAssert.AreEqual(expected, actual, comparer);
        }

    }
}