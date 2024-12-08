namespace AdventOfCode2._1;

class Program
{
    static void Main()
    {
        var input = File.ReadLines($"{Environment.CurrentDirectory}\\input.txt");
        int total = 0;
        
        foreach (var line in input)
        {
            bool increasing = false;
            bool safe = true;
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
                
                if (increasing && currentNum >= nextNum) { safe = false; break; }
                if (!increasing && currentNum <= nextNum) { safe = false; break; }
                
                // We've covered the increase / decrease pattern.
                if (!(Math.Abs(currentNum - nextNum) <= 3)) { safe = false; break; }
                
                if (currentNum == nextNum) { safe = false; break; }

            }

            if (safe)
            {
                //Console.WriteLine(line);
                total++;
            }
        }
        Console.WriteLine(total);
        
    }
}