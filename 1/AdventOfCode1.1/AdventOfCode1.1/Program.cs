namespace AdventOfCode1._1;

class Program
{
    static void Main()
    {
        var input = File.ReadAllLines($"{Environment.CurrentDirectory}\\input.txt");
        var leftList = new int[input.Length];
        var rightList = new int[input.Length];
        var total = 0;
        // We get two sets of numbers, we need to split them into their own lists and sort them in size order.
        
        // Building the individual lists.
        for (var i = 0; i < input.Length; i++)
        {
            var splitInput = input[i].Split("   ");
            leftList[i] = int.Parse(splitInput[0]);
            rightList[i] = int.Parse(splitInput[1]);
        }
        
        leftList = (leftList.OrderBy(x => x)).ToArray();
        rightList = (rightList.OrderBy(x => x)).ToArray();

        for (var b = 0; b < input.Length; b++)
        {
            Console.WriteLine($"Left List: {leftList[b]} Right List: {rightList[b]}");
            
            var difference = Math.Abs(leftList[b] - rightList[b]); 
            total += difference;
            Console.WriteLine($"Difference: {difference}");
        }
        Console.WriteLine($"Total Difference: {total}");
    }
}