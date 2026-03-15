using GildedRoseKata.Models;

namespace GildedRoseKata
{
    internal class ItemFactory()
    {

        public static IItem CreateItem(Item item)
        {
            // To upper to remove case checking
            var itemName = item.Name.ToUpper();

            // Just a simple if else for now, this could be refactored if this grows
            if (itemName == "AGED BRIE")
            {
                return new AgedBrie(item.Name, item.SellIn, item.Quality);
            }
            else if (itemName.Contains("SULFURAS"))
            {
                return new Sulfuras(item.Name, item.SellIn, item.Quality);
            }
            else if (itemName.Contains("BACKSTAGE PASSES"))
            {
                return new BackstagePasses(item.Name, item.SellIn, item.Quality);
            }
            else if (itemName.Contains("CONJURED"))
            {
                return new ConjuredItem(item.Name, item.SellIn, item.Quality);
            }


            //Default
            return new BaseItem(item.Name, item.SellIn, item.Quality);
        }


    }
}