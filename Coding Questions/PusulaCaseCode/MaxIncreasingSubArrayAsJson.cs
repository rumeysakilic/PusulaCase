using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class MaxIncreasingSubArrayAsJson
{  
    public static string Find(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
            return "[]";

        List<int> maxSubarray = new List<int>();
        List<int> currentSubarray = new List<int> { numbers[0] };
        int maxSum = numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentSubarray.Add(numbers[i]);
            }
            else
            {
                if (currentSubarray.Sum() > maxSum)
                {
                    maxSum = currentSubarray.Sum();
                    maxSubarray = new List<int>(currentSubarray);
                }
                currentSubarray = new List<int> { numbers[i] };
            }
        }

        if (currentSubarray.Sum() > maxSum)
            maxSubarray = currentSubarray;

        return JsonSerializer.Serialize(maxSubarray);
    }
}
