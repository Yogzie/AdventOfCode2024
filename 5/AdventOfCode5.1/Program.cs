using System.Data;

namespace AdventOfCode5._1;

class Program
{
    static void Main(string[] args)
    {

        var ruleSet = File.ReadAllLines($"{Environment.CurrentDirectory}\\rules.txt");
        var input = File.ReadAllLines($"{Environment.CurrentDirectory}\\input.txt");

        var total = 0;
        List<string[]> goodInputList = new List<string[]>();
 
        // This is a psuedo sorting algorithm. Need to:
        // 1. loop through the line for the length of the line in the test case it's 7
        // 2. for each item in the line check against every single rule to make sure we're not violating any.
        // 3. If we're not violating any rules on that row, add it to goodInputLIst

        
        // Test String
        // 75,47,61,53,29
        

        // 97|13
        // 97|61
        // 97|47
        
        for (int i = 0; i < input.Length; i++) // For every line of input check if it's following the rules
        {
            if (DoesListBreakRule(ruleSet, input[i].Split(",")))
            {
                goodInputList.Add(input[i].Split(","));
            }
        }

        foreach (var goodInput in goodInputList)
        {
            total = total + Convert.ToInt32(goodInput[goodInput.Length / 2]);
        }
        Console.WriteLine(total);
    }

    
    
    public static bool DoesListBreakRule(string[] ruleSet, string[] pageList)
    {
        int beforeNum = 0;
        int afterNum = 0;
        // Logic for checking the pagelist against the rules now. 
        foreach (var rule in ruleSet)
        {
            // 47|53
            //75,47,61,53,29
            var ruleNumbers = rule.Split("|");
            beforeNum = Convert.ToInt32(ruleNumbers[0]);
            afterNum = Convert.ToInt32(ruleNumbers[1]);
            for (int i = 0; i < pageList.Length; i++)
            {
                if (pageList[i] == afterNum.ToString())
                {
                    for (int j = 0; j < pageList.Length; j++)
                    {
                        if (pageList[j] == beforeNum.ToString() && j > i)
                        {
                            return false;
                        }    
                    }
                } 
            }
        }
        return true;
    }
}