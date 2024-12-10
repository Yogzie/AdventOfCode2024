namespace AdventOfCode9._1;

class Program
{
    static void Main()
    {
        // input: 2333133121414131402
        var input = File.ReadAllText("input.txt");
        var isSpace = true;
        var blockID = 0;
        var outputStr = "";
        var volume = 0;
        
        foreach (var c in input)
        {
            
            volume = Convert.ToInt32(c.ToString());
            
            if (isSpace)
            {
                for (var i = 0; i < volume; i++)
                {
                    outputStr += blockID.ToString();
                }
                blockID++;
            }
            else
            {
                for (var i = 0; i < volume; i++)
                {
                    outputStr += ".";
                }
            }
            
            isSpace = !isSpace;
        }
        // string has been converted to their dotted strings
        
        // Sort the string.
        var earliestSpaceIndex = 0;
        var blockedStr = outputStr.ToList();
        for (var x = blockedStr.Count-1; x >= 0; x--)
        {
            if (blockedStr.IndexOf('.') >= x){ break; }
            earliestSpaceIndex = blockedStr.IndexOf('.');
            
            blockedStr[earliestSpaceIndex] = blockedStr[x];
            blockedStr[x] = '.';
        }
        foreach (var s in blockedStr)
        {
            Console.Write(s);
        }
        // We have the sortedStr now lets calculate the checksum
        
        // Formula after sorting is the sum of all the index * ID 
        Int64 total = 0;
        
        for (var k = 0; k < blockedStr.Count; k++)
        {
            if (blockedStr[k] == '.') continue;
            
            total += (k * Convert.ToInt32(blockedStr[k].ToString()));
            //Console.WriteLine($"Character: {sortedStr[k]} Index: {k} Adding {(k * Convert.ToInt32(sortedStr[k].ToString()))} to {total}");
        }
        
        Console.WriteLine($"\n{total}");
    }
}
