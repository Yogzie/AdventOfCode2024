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

        

        // 75,97,47,61,53 becomes 97,75,47,61,53.
        // 61,13,29 becomes 61,29,13.
        
        // 97,13,75,29,47 becomes 97,75,47,29,13
        
        
        for (var i = 0; i < input.Length; i++) // For every line of input check if it's following the rules
        {
            if (!DoesListBreakRule(ruleSet, input[i].Split(",")))
            {
                var pageList = input[i].Split(",");
                // Bad Input[i] sort it.
                //Console.WriteLine(pageList[0]);
                for (var j = 0; j < pageList.Length; j++)
                {
                    

                    var tempNum = "0"; 

                    foreach(var r in ruleSet)
                    {
                         var beforeNum = r.Split("|")[0];
                         var afterNum = r.Split("|")[1];
                         if (pageList[j] != afterNum) { continue; }
                         
                         for (var k = 0; k < pageList.Length; k++)
                         {
                             if ((pageList[k] == beforeNum) && (k > j))
                             {

                                 // Flip the indexes of the numbers
                                 tempNum = pageList[k];
                                 pageList[k] = pageList[j];
                                 pageList[j] = tempNum;
                                 

                                 if (DoesListBreakRule(ruleSet, pageList))
                                 {
                                    goodInputList.Add(pageList);
                                 }
                                 else
                                 {
                                     k = 0;
                                     j = 0;
                                 }
                             }
                         }
                         
                    }
                    
                }
            }
            else
            {
                //goodInputList.Add(input[i].Split(","));
            }
        }

        foreach (var goodInput in goodInputList)
        {
            total += Convert.ToInt32(goodInput[goodInput.Length / 2]); ;
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
                            return false; // Doesn't break rule 
                        }    
                    }
                } 
            }
        }
        return true; // Does break rule
    }
}