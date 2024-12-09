namespace AdventOfCode2._1;

class Program
{
    static void Main()
    {
        var input = File.ReadLines($"{Environment.CurrentDirectory}\\input.txt");
        int total = 0;
        
        foreach (var line in input)
        {
            var increasing = false;
            var safe = true;
            var badLevelCount = 0;
            var report = line.Split(" ");
            
            for (var i = 0; i < report.Length - 1; i++)
            {
                if (i == report.Length - 1) { break; }
                int currentNum = Convert.ToInt32(report[i]);
                int nextNum = Convert.ToInt32(report[i + 1]);
                if (i == 0 && currentNum > nextNum)
                {
                    increasing = false;
                }
                else if ((i == 0) && currentNum < nextNum)
                {
                    increasing = true;
                }
                
                if (increasing && currentNum >= nextNum) { badLevelCount++;}
                if (!increasing && currentNum <= nextNum) { badLevelCount++; }
                
                // We've covered the increase / decrease pattern.
                if (!(Math.Abs(currentNum - nextNum) <= 3)) { badLevelCount++; }
                
                if (currentNum == nextNum) { badLevelCount++; }
    
            }
            Console.WriteLine($"{line} : {badLevelCount}");
            if (badLevelCount <= 1)
            {
                
                total++;
            }
        }
        Console.WriteLine(total);
        
    }
}