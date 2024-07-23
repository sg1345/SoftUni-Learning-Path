internal class Program
{
    static void Main()
    {
        var dnaLength = int.Parse(Console.ReadLine());
        var array = Array.Empty<int>();
        //var array = new int[dnaLength];
        
        var bestSequenceIndex = 0;
        var bestSequenceSum = 0;
        var bestSequenceCount = 0;
        var bestArray = Array.Empty<int>();
        //var bestArray = new int[dnaLength];
        var leftmostStartingSequenceIndex = int.MaxValue;

        var sequenceIndex = 0;

        while (true)
        {            
            var input = Console.ReadLine();
            
            if (input == "Clone them!")
            {
                Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
                Console.WriteLine(string.Join(" ", bestArray));
                break;
            }


            array = input.Split("!",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Console.WriteLine(string.Join(" ",array));

            if (dnaLength != array.Length)
            {
                continue;
            }

            sequenceIndex++;
            
            var arraySum = 0;    
            var startingSequenceIndex = 0;
            var currentBestSequenceCount = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
               var sequenceCount = 0;
               
                if (array[i] == 1)
                {
                    sequenceCount++;
                    arraySum += array[i];

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] == array[j])
                        {
                            sequenceCount++;
                        }
                        else
                        {                           
                                break;                        
                        }
                    }

                    if (sequenceCount > currentBestSequenceCount)
                    {
                        startingSequenceIndex = i;
                        currentBestSequenceCount = sequenceCount;
                    }
                }

            }

            /*            if ((currentBestSequenceCount > bestSequenceCount)
                            || startingSequenceIndex < leftmostStartingSequenceIndex
                            || arraySum > bestSequenceSum)*/
            if ((currentBestSequenceCount > bestSequenceCount)
            || (currentBestSequenceCount == bestSequenceCount && startingSequenceIndex < leftmostStartingSequenceIndex)
            || (currentBestSequenceCount == bestSequenceCount && startingSequenceIndex == leftmostStartingSequenceIndex
                                                     && arraySum > bestSequenceSum))
            {
                bestSequenceCount = currentBestSequenceCount;
                leftmostStartingSequenceIndex = startingSequenceIndex;
                bestArray = array;
                bestSequenceSum = arraySum;
                
                bestSequenceIndex = sequenceIndex;
            }
        }
    }
}