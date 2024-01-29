namespace GrokingAlgorithms;

public class QuickSort
{
    public int[] QSort(int[] arr)
    {
        return Sort(arr, 0, arr.Length - 1);
    }

    public int[] QSortOptimal(int[] arr)
    {
        return OptimalSort(arr, 0, arr.Length-1);
    }

    private int[] OptimalSort(int[] array, int first, int last)
    {
        if (first < last)
        {
            var left = first;
            var right = last;
            var middle = array[(right + left) / 2];

            do
            {
                while (array[left] < middle)
                {
                    left++;
                }
                
                while (array[right] > middle)
                {
                    right--;
                }

                if (left <= right)
                {
                    (array[left], array[right]) = (array[right], array[left]);
                    left++;
                    right--;
                }

            } while (left <= right);

            OptimalSort(array, first, right);
            OptimalSort(array, left, last);
        }

        return array;
    }

    private int[] Sort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex) // один элемент
        {
            return array;
        }

        var pivot = Partition(array, minIndex, maxIndex);
        Sort(array, minIndex, pivot - 1);
        Sort(array, pivot +1, maxIndex);

        return array;
    }

    private int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot =  minIndex - 1;

        for (int i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                (array[pivot], array[i]) = (array[i], array[pivot]);
            }
        }

        pivot++;
        
        (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);

        return pivot;
    }
}