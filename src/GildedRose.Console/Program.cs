using GildedRose.Console.Extensions;
using GildedRose.Console.Services;
using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        public static IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };

            Service.ItemService.UpdateQuality();

            System.Console.ReadKey();

        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public enum ItemNameEnum
    {
        [StringValue("Aged Brie")]
        AgedBrie,
        [StringValue("Backstage passes to a TAFKAL80ETC concert")]
        Backstage,
        [StringValue("Sulfuras, Hand of Ragnaros")]
        Sulfuras,
        [StringValue("Conjured Mana Cake")]
        Conjured,
    }
}
