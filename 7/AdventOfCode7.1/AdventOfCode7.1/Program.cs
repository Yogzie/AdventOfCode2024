namespace AdventOfCode7._1;

class Program
{
    static void Main()
    {
        var input = File.ReadLines("input.txt");
        long runningTotal = 0;

        foreach (var line in input)
        {
            long expectedTotal = Convert.ToInt64(line.Split(":").First());

            string[] numberList = line.Split(":").Last().Trim().Split(" ");
            // 292: 11 6 16 20
            int spaceCount = numberList.Length - 1;

            int possibilities = Convert.ToInt32(Math.Pow(3,spaceCount));

            while (possibilities > 0)
            {
                long workingNumber = Convert.ToInt64(numberList[0]);
                
                possibilities--;
                var attempt = Convert.ToString(possibilities, 2).PadLeft(spaceCount, '0');
                
                for (var i = 0; i < attempt.Length; i++)
                {
                    if (attempt[i] == '0')
                    {
                        workingNumber = workingNumber * Convert.ToInt64(numberList[i + 1]);
                    }
                    else
                    {
                        workingNumber = workingNumber + Convert.ToInt64(numberList[i + 1]);
                    }
                }

                if (workingNumber == expectedTotal)
                {
                    
                    runningTotal += workingNumber;
                    Console.WriteLine($"The number {workingNumber} is {expectedTotal}");
                    break;
                    
                }

            }

        } 
        Console.WriteLine($"The total number is {runningTotal}");
    }
}