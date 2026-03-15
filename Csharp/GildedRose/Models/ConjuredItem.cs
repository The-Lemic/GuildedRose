using GildedRoseKata.Models;

namespace GildedRoseKata
{
    internal class ConjuredItem(string name, int sellIn, int quality) : BaseItem(name, sellIn, quality)
    {
        /// <summary>
        /// Update Quality for Conjured Items. 
        /// It was never really covered in the breif what would happen if you had a Counjured concert ticket, Sulfuras or Aged Brie, this would be something that I would check with product.
        /// The interactions of a conjured aged brie were unclear would it increase in quality half as fast? or twice as fast due to the 2x modifier?
        /// The interactions become even more complicated when conjuring a concert ticket, should we round up or round down?
        /// For this reason i have assumed that conjured items can only apply to the base items.
        /// This is why I have a copy of the Base item Method here with just the number change.
        /// I could have spent my time over complicating this and extracting out the modifier however that violates the KISS priciple of practical programming.
        /// This copy and place solution is fine for now until the next update where we add "Enchanted" items which could perform another modification operation, in which case the base class should be extended and this class also refactored.
        /// </summary>
        public override void UpdateQuality()
        {
            // Checking if quality is below 0 before i start modifying, I noticed that it wasnt always being reset to 0 in the original code
            // UpdateQuality_QualityWouldBeNegative_ReturnQualityOf0 her is the test case that covers it. I think this is a potential mistake in the original
            if (Quality > 0)
            {
                // Base reduction
                Quality -= 2;

                // Expired Reduction
                if (SellIn <= 0)
                {
                    Quality -= 2;
                }

                // Reset Quality to 0 as it cannot be below it
                if (Quality < 0)
                {
                    Quality = 0;
                }
            }
        }
    }
}