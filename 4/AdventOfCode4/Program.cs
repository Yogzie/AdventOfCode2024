namespace AdventOfCode4;

static class Program
{
    static void Main(string[] args)
    {
        
        int total = 0;
        string input = File.ReadAllText("C:\\Users\\14hod\\Desktop\\Coding\\c#\\Advent\\4\\AdventOfCode4\\input.txt");

        var inputTable = input.Split("\r\n");
        List<List<string>> charTable = new List<List<string>>();
        
        for(int i = 0; i < inputTable.Length; i++)
        {
            charTable.Add(inputTable[i].Split("").ToList());
        }
        
        
        // Search Normally 
        
        
        int clamp = input.IndexOf("\r");
        
        
        // Forward and Backward Horizontal Check (Done)
        foreach (var a in inputTable)
        {
            int aCounter = 0;
            foreach (var letter in a)
            {
                if (aCounter == clamp - 4) { break; }
                string horizontalInput = a.Substring(aCounter, 4);
                if (horizontalInput == "XMAS") { total += 1; }
                if (horizontalInput == "SMAX") { total += 1; }
                aCounter++;
            }
        }
        
        // Search Diagonally Forward
        int bCounter = 0;
        foreach (var b in charTable)
        {
            
            
            
            bCounter++;
        }

    }


}
//

// Need to search the string as a normal string for XMAS or SMAX instances.
// Need to search vertically too. Best method in my opinion is to make it a table that's clamped at the line length.
// so on the table we can +1 across, +1 down to get the diagonal. 
// To get the verticals we can just read in rows rather than in columns.

// Need to perform these checks both forward and backward.

// MMMSXXMASM
// MSAMXMSMSA
// AMXSXMAAMM
// MSAMASMSMX
// XMASAMXAMM
// XXAMMXXAMA
// SMSMSASXSS
// SAXAMASAAA
// MAMMMXMMMM
// MXMXAXMASX

//