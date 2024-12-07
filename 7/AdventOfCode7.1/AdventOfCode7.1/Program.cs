namespace AdventOfCode7._1;

class Program
{
    static void Main()
    {
        var input = File.ReadLines("input.txt");
        long runningTotal = 0;
        // formula for the possiblilities is| # of Operands to the power of # of spaces
        foreach (var line in input)
        {
            long expectedTotal = Convert.ToInt64(line.Split(":").First());

            string[] numberList = line.Split(":").Last().Trim().Split(" ");
            // 292: 11 6 16 20
            var spaceCount = numberList.Length - 1;

            var possibilities = Convert.ToInt32(Math.Pow(3,spaceCount));
            
            while (possibilities > 0)
            {
                long workingNumber = Convert.ToInt64(numberList[0]);

                possibilities--;
                var attempt =ConvertToBase3(possibilities).PadLeft(spaceCount, '0');

                for (var i = 0; i < attempt.Length; i++)
                {
                    if (attempt[i] == '0')
                    {
                        workingNumber = workingNumber * Convert.ToInt64(numberList[i + 1]);
                    }
                    else if (attempt[i] == '1')
                    {
                        workingNumber = workingNumber + Convert.ToInt64(numberList[i + 1]);
                    }
                    else 
                    {
                        workingNumber = Convert.ToInt64((Convert.ToString(workingNumber) + numberList[i + 1]));
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
        
        static string ConvertToBase3(int number)
        {
            if (number == 0) return "0"; // Special case for 0

            string result = "";
            while (number > 0)
            {
                result = (number % 3) + result; // Prepend the remainder (mod 3)
                number /= 3; // Divide the number by 3
            }

            return result;
        }
        Console.WriteLine($"The total number is {runningTotal}");
    }
}