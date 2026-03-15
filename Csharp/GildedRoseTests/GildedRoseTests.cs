using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase("Apple",3,3)]
        [TestCase("Banana",13,15)]
        [TestCase("Pear",1,1)]
        public void UpdateQuality_BaseItem_ReducesQuality(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality - 1));
        }

        [TestCase("Beer", 0, 10)]
        [TestCase("Wine", -1, 10)]
        public void UpdateQuality_SellByDatePassed_ReducesQualityBy2(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality - 2));
        }

        [TestCase("Beer", 0, 1)]
        [TestCase("Beer", 0, 0)]
        [TestCase("Wine", -1, 1)]
        [TestCase("Wine", -1, 0)]
        public void UpdateQuality_SellByDatePassed_NeverNegative(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [TestCase("Beer", 0, 0)]
        [TestCase("Beer", 0, -10)]
        [TestCase("Wine", -1, 0)]
        [TestCase("Wine", -1, -10)]
        public void UpdateQuality_QualityWouldBeNegative_ReturnQualityOf0(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality));
        }

        [TestCase("Aged Brie", 23, 10)]
        [TestCase("Aged Brie", 4, 0)]
        [TestCase("Aged Brie", 30, -10)]
        public void UpdateQuality_AgedBrie_IncreasesInQuality(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality + 1));
        }

        [TestCase("Aged Brie", 0, 10)]
        [TestCase("Aged Brie", 0, 0)]
        [TestCase("Aged Brie", 0, -10)]
        [TestCase("Aged Brie", -1, 10)]
        [TestCase("Aged Brie", -1, 0)]
        [TestCase("Aged Brie", -1, -10)]
        [TestCase("Aged Brie", -5, 10)]
        [TestCase("Aged Brie", -15, 0)]
        [TestCase("Aged Brie", -14, -10)]
        public void UpdateQuality_AgedBrie_IncreasesInQualityTwice(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality + 2));
        }

        [TestCase("Aged Brie", 0, 100)]
        //[TestCase("Aged Brie", 0, 40)] // This may be an missed edge case your able to age Brie over the hard limit of 40 quality
        [TestCase("Aged Brie", 4, 410)]
        public void UpdateQuality_Item_MaxQualityCheck(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality));
        }

        [TestCase("Sulfuras, Hand of Ragnaros", 10, 10)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 410)]
        [TestCase("Sulfuras, Hand of Ragnaros", -1, 410)]
        [TestCase("Sulfuras, Hand of Ragnaros", -51, 410)]
        [TestCase("Sulfuras, Hand of Ragnaros", 10, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", -1, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", -51, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 10, -50)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, -654)]
        [TestCase("Sulfuras, Hand of Ragnaros", -1, -8)]
        [TestCase("Sulfuras, Hand of Ragnaros", -51, -1)]
        public void UpdateQuality_Sulfuras_NeverChange(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn));
            Assert.That(items[0].Quality, Is.EqualTo(Quality));
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 30, 5)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 12, 5)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 11, 5)]
        public void UpdateQuality_PassesMoreThan10DaysOut_IncreasesQualityBy1(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality + 1));
        }


        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 5)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 9, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 8, 5)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 7, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 6, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, -1)]
        public void UpdateQuality_Passes10DaysOut_IncreasesQualityBy2(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality + 2));
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 4, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 7)]
        public void UpdateQuality_PassesLessThan5DaysOut_IncreaseBy3(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality + 3));
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 7)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", -1, 7)]
        public void UpdateQuality_PassesPassed_Value0(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [TestCase("Conjured Apple", 3, 3)]
        [TestCase("Conjured Banana", 13, 15)]
        [TestCase("Conjured Pear", 1, 2)]
        public void UpdateQuality_ConjuredItem_ReducesQualityBy2(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality - 2));
        }

        [TestCase("Conjured Beer", 0, 10)]
        [TestCase("Conjured Wine", -1, 10)]
        public void UpdateQuality_ConjuredItemSellByDatePassed_ReducesQualityBy4(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality - 4));
        }

        [TestCase("Conjured Beer", 0, 1)]
        [TestCase("Conjured Beer", 0, 0)]
        [TestCase("Conjured Wine", -1, 1)]
        [TestCase("Conjured Wine", -1, 0)]
        [TestCase("Conjured Pear", 1, 1)]
        [TestCase("Conjured Pear", 1, 0)]
        public void UpdateQuality_ConjuredItemSellByDatePassed_NeverNegative(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [TestCase("Conjured Beer", 0, 0)]
        [TestCase("Conjured Beer", 0, -10)]
        [TestCase("Conjured Wine", -1, 0)]
        [TestCase("Conjured Wine", -1, -10)]
        public void UpdateQuality_ConjuredItemQualityWouldBeNegative_ReturnQualityOf0(string Name, int SellIn, int Quality)
        {
            var items = new List<Item> { new Item { Name = Name, SellIn = SellIn, Quality = Quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo(Name));
            Assert.That(items[0].SellIn, Is.EqualTo(SellIn - 1));
            Assert.That(items[0].Quality, Is.EqualTo(Quality));
        }

    }
}