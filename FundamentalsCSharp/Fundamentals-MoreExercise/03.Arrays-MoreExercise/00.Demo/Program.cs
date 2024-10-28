internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        List<int> result = FindLIS(numbers);

        Console.WriteLine(string.Join(' ',result));
    }

    public static List<int> FindLIS(int[] nums)
    {
        if (nums.Length == 0) return new List<int>();

        int[] lengths = new int[nums.Length];
        int[] predecessors = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            lengths[i] = 1;
            predecessors[i] = -1;

            var validPredecessors = Enumerable.Range(0, i)
                .Where(j => nums[i] > nums[j] && lengths[i] < lengths[j] + 1);

            foreach (var j in validPredecessors)
            {
                lengths[i] = lengths[j] + 1;
                predecessors[i] = j;
            }
        }

        int maxIndex = Array.IndexOf(lengths, lengths.Max());

        List<int> result = new List<int>();
        while (maxIndex != -1)
        {
            result.Add(nums[maxIndex]);
            maxIndex = predecessors[maxIndex];
        }

        result.Reverse();
        return result;
    }

}