namespace AdventOfCode1._1;

class QuantityOfNumber
{
    public int Number { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        var input = File.ReadAllLines($"{Environment.CurrentDirectory}\\input.txt");
        var leftList = new int[input.Length];
        var rightList = new int[input.Length];
        var total = 0;
        var part2Total = 0;
        // We get two sets of numbers, we need to split them into their own lists and sort them in size order.
        
        var leftOccurences = new List<QuantityOfNumber>();
        var rightOccurences = new List<QuantityOfNumber>();
        
        // Building the individual lists.
        for (var i = 0; i < input.Length; i++)
        {
            var splitInput = input[i].Split("   ");
            leftList[i] = int.Parse(splitInput[0]);
            AddOccurence(leftList[i], ref leftOccurences);
            rightList[i] = int.Parse(splitInput[1]);
            AddOccurence(rightList[i], ref rightOccurences);
        }
        // Not needed for part 2
        //leftList = (leftList.OrderBy(x => x)).ToArray();
        //rightList = (rightList.OrderBy(x => x)).ToArray();

        
        // Part 2 Processing:

        foreach (var m in leftOccurences)
        {
            // We have our occurence, 3 : 3
            
            foreach (var y in rightOccurences)
            {
                // Match the number in rightOccurrences
                if (m.Number != y.Number) { continue; }

                part2Total += ((Math.Min(y.Quantity, m.Quantity) * y.Number) * (y.Quantity));
                Console.WriteLine($"Part 2: {part2Total}");
            }
        }
        
        
        
        
        // Not needed for part 2
        for (var b = 0; b < input.Length; b++)
        {
            //Console.WriteLine($"Left List: {leftList[b]} Right List: {rightList[b]}");
            
            var difference = Math.Abs(leftList[b] - rightList[b]); 
            total += difference;
            //Console.WriteLine($"Difference: {difference}");
        }
        //Console.WriteLine($"Total Difference: {total}");
    }
    public static void AddOccurence(int num, ref List<QuantityOfNumber>list)
    {
        foreach (var a in list)
        {
            if (a.Number == num)
            {
                a.Quantity++;
                return;
            }
        }
        
        list.Add(new QuantityOfNumber { Number = num, Quantity = 1 });
    }
}

