using GildedRose.Console.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Services
{
    public class ItemService : IDisposable
    {
        // A list of items which must be updated
        public readonly IList<Item> Items;

        /// <summary>
        /// Constructor of the item service in order to set the item list for updating
        /// </summary>
        /// <param name="_items">List of all items which must be updated</param>
        public ItemService(IList<Item> _items)
        {
            Items = _items;
        }

        /// <summary>
        /// Update all items
        /// </summary>
        public void UpdateQuality()
        {
            UpdateNormalItems();
            UpdateAgedBrieItems();
            UpdateBackstageItems();
            UpdateConjuredItems();
            UpdateSulfurasItems();
        }

        /// <summary>
        /// Update the quality and sellin properties of Normal items
        /// </summary>
        private void UpdateNormalItems()
        {
            // Minus 1 unit from quality and minus 1 unit from sellin
            Items
                .Where(item =>
                            item.Name != StringEnum.GetStringValue(ItemNameEnum.AgedBrie) &&
                            item.Name != StringEnum.GetStringValue(ItemNameEnum.Backstage) &&
                            item.Name != StringEnum.GetStringValue(ItemNameEnum.Conjured) &&
                            item.Name != StringEnum.GetStringValue(ItemNameEnum.Sulfuras) &&
                            item.Quality > 0)
                .ToList()
                .ForEach(item => { item.Quality--; item.SellIn--; });
        }

        /// <summary>
        /// Update the quality and sellin properties of Aged Brie items
        /// </summary>
        private void UpdateAgedBrieItems()
        {
            // Add 1 unit to quality and minus 1 unit from sellin
            Items
                .Where(item =>
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.AgedBrie) &&
                            item.Quality < 50)
                .ToList()
                .ForEach(item => { item.Quality++; item.SellIn--; });
        }

        /// <summary>
        /// Update the quality and sellin properties of Baclstage items
        /// </summary>
        private void UpdateBackstageItems()
        {
            // Add 1 unit to quality and minus 1 unit from sellin
            Items
                .Where(item =>
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.Backstage) &&
                            item.Quality < 50)
                .ToList()
                .ForEach(item => { item.Quality++; item.SellIn--; });

            // Add 1 more unit to quality if sellin 10 days or less (it means add 2 unit to quality)
            Items
                .Where(item =>
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.Backstage) &&
                            item.SellIn < 11 &&
                            item.Quality < 50)
                .ToList()
                .ForEach(item => item.Quality++);

            // Add 1 more unit to quality if sellin 5 days or less (it means add 3 unit to quality)
            Items
                .Where(item =>
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.Backstage) &&
                            item.SellIn < 6 &&
                            item.Quality < 50)
                .ToList()
                .ForEach(item => item.Quality++);

            // Drop quality to 0 if the sellin less than 0
            Items
                .Where(item =>
                            item.SellIn < 0 &&
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.Backstage))
                .ToList()
                .ForEach(item => item.Quality = 0);

        }

        /// <summary>
        /// Update the quality and sellin properties of Conjured items
        /// </summary>
        private void UpdateConjuredItems()
        {
            // Minus 2 unit from quality and minus 1 unit from sellin
            Items
                .Where(item =>
                            item.Name == StringEnum.GetStringValue(ItemNameEnum.Conjured) &&
                            item.Quality > 0)
                .ToList()
                .ForEach(item => { item.Quality = item.Quality - 2; item.SellIn--; });
        }

        /// <summary>
        /// Update the quality and sellin properties of Sulfuras items
        /// </summary>
        private void UpdateSulfurasItems()
        {
            // Nothing to do for these items if in future we need changes add HERE!
        }


        /// <summary>
        /// Dispose object of application context
        /// </summary>
        public void Dispose()
        {
        }
    }
}
