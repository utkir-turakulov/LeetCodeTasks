using System.Linq;

namespace LeetCode75.CanPlaceFlowers;

public static class CanPlaceFlowersSolution
{
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        var flowers = n;

        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowers == 0)
            {
                return true;
            }
            
            var nextIndex = i + 1;
            var prevIndex = i - 1;

            if (flowerbed.ElementAtOrDefault(nextIndex) == 0 &&
                flowerbed.ElementAtOrDefault(prevIndex) == 0 &&
                flowerbed.ElementAtOrDefault(i) == 0)
            {
                flowers--;

                flowerbed[i] = 1;
            }
            
        }

        return flowers == 0;

    }
}