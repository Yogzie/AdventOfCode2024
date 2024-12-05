namespace AdventOfCode4._2;

class Program
{
    static void Main(string[] args)
    {
        // Find X and search all around for the MAS
        string input = File.ReadAllText(Environment.CurrentDirectory + "\\input.txt");

        var total = 0;
        
        char[,] characterTable = To2DArray(input);

        for (var y = 1; y < characterTable.GetLength(1) - 1; y++)
        {
            for (var x = 1; x < characterTable.GetLength(0) - 1; x++)
            {
                if (characterTable[x, y] == 'A')
                {
                    if ((characterTable[x - 1, y - 1] == 'S') && (characterTable[x + 1,y + 1] == 'M') || (characterTable[x - 1, y - 1] == 'M') && (characterTable[x + 1,y + 1] == 'S'))
                    {
                        if ((characterTable[x + 1, y - 1] == 'S') && (characterTable[x - 1, y + 1] == 'M') ||
                            (characterTable[x + 1, y - 1] == 'M') && (characterTable[x - 1, y + 1] == 'S'))
                        {
                            total += 1;
                        }
                    }
                    
                    
                    //total += FindWordInstances(x, y, "XMAS",characterTable);
                }
            }
        }
        
        Console.WriteLine(total);
        
    }
    public static int FindWordInstances(int x, int y, string targetWord, char[,] characterTable)
    {
        var result = 0;

        for (var vectorX = -1; vectorX <= 1; vectorX++)
        {
            for (var vectorY = -1; vectorY <= 1; vectorY++)
            {
                if (vectorX == 0 && vectorY == 0) { continue; }

                if (CheckWordFromVector(x, y, vectorX, vectorY, targetWord, characterTable))
                {
                    result++;
                }
            }
        }
        
        // We've found X now we need to search the vectors for M 
        return result;
    }
    public static int FindWordInstancesPart2(int x, int y, string targetWord, char[,] characterTable)
    {
        var result = 0;

        for (var vectorX = -1; vectorX <= 1; vectorX++)
        {
            for (var vectorY = -1; vectorY <= 1; vectorY++)
            {
                if (vectorX == 0 && vectorY == 0) { continue; }

                // Neither vectors are 0 so we have a diagonal vector.
                
                // in the function IsValidXPattern we can alternate a boolean (reset here) which will signal which axis we're on. 
                
                
                
                if (CheckWordFromVector(x, y, vectorX, vectorY, targetWord, characterTable))
                {
                    result++;
                }
                                
            }
        }
        
        // We've found X now we need to search the vectors for M 
        return result;
    }

    public static bool IsValidXPattern(int originX, int originY, int vectorX, int vectorY, string targetWord, char[,] characterTable)
    {
        
        return true;
    }
    public static bool CheckWordFromVector(int originX, int originY, int vectorX, int vectorY, string targetWord, char[,] characterTable)
    {
        
        var x = originX;
        var y = originY;
        for (var characterIndex = 0; characterIndex < targetWord.Length; characterIndex++)
        {
            if (targetWord[characterIndex] != characterTable[x, y]) { return false; }
            
            if (characterIndex == targetWord.Length-1) { return true;}
            
            x += vectorX;
            y += vectorY;
            
            if (x < 0 || x >= characterTable.GetLength(0)) { return false; }

            if (y < 0 || y >= characterTable.GetLength(1)) { return false; }

        }
        return true;
    }
    public static char[,] To2DArray(string inputString)
    {
        var rows = inputString.Split("\r\n");
        
        var matrix = new char[rows[0].Length,rows.Length];
        
        for(var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
        {
            for ( var columnIndex = 0; columnIndex < rows[rowIndex].Length; columnIndex++)
            {
                matrix[columnIndex, rowIndex] = rows[rowIndex][columnIndex];
            }
        }
        
        return matrix;
    }
    
}