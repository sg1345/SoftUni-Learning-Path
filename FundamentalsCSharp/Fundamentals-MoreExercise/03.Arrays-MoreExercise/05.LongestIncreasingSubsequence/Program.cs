using System.Collections.Generic;
using System.ComponentModel;

internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] lisLength = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            List<int> sequences = new List<int>(); //longest increasing subsequence 
            sequences.Add(array[i]);

            for (int j = i - 1; j >= 0; j--)
            {
                if (IsTheLastNumberBiggerFromLIS(array[j], sequences.Last()))
                {
                    sequences.Add(array[j]);

                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (LeftMostCheck(array, sequences, i, j, k) && (k != 0))
                        {
                            sequences[sequences.Count - 1] = array[k];
                            break;
                        }
                    }
                }
            }

            lisLength[i] = sequences.Count;

            /*            sequences.Reverse();
                        Console.WriteLine(string.Join(' ', sequences));*/
        }

        List<int> lis = new List<int>();

        int maxNumber = lisLength.Max();
        int resultIndex = Array.IndexOf(lisLength, maxNumber);

        lis.Add(array[resultIndex]);

        for (int i = resultIndex - 1; i >= 0; i--)
        {
            if (IsTheLastNumberBiggerFromLIS(array[i], lis.Last()))
            {
                lis.Add(array[i]);
                for (int j = i - 1; j >= 0; j--)
                {
                    if (LeftMostCheck(array, lis, resultIndex, i, j) && (j != 0))
                    {
                        lis[lis.Count - 1] = array[j];
                        break;
                    }
                }
            }

            if (LeftMostCheck(array, lis, resultIndex, i, i - 1))
            {
                lis[lis.Count - 1] = array[i - 1];
            }
        }

        lis.Reverse();
        Console.WriteLine(string.Join(" ", lis));
    }

    static bool IsTheLastNumberBiggerFromLIS(int current, int last)
    {
        return last > current;
    }

    static bool LeftMostCheck(int[] array, List<int> list, int i, int j, int k)
    {

        return list.Count - 1 > 0 && k >= 0 &&
               list[list.Count - 2] > array[k] &&
               array[k] > list.Last();
    }
}