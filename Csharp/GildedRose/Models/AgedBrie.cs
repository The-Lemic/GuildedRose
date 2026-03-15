namespace GildedRoseKata.Models
{
    internal class AgedBrie(string name, int sellIn, int quality) : BaseItem(name, sellIn, quality)
    {
        /// <summary>
        /// Update Quality for Aged Brie. Increases in quality by 1, and if the sell by date has passed increases in quality by 2.
        /// </summary>
        public override void UpdateQuality()
        {
            // Cannot Increase Quality above 50
            if (Quality < 50)
            {
                ++Quality;
                if (SellIn <= 0 && Quality < 50)
                {
                    ++Quality;
                }
            }
        }
    }
}