namespace AdventOfCode8._1;

class Vector
{
    public int X { get; set; } // Across
    public int Y { get; set; } // Down
}
class Antenna
{
    public char Character { get; set; }
    public List<Vector> Position { get; set; }
}

class Program
{
    static void Main()
    {
        var input = File.ReadAllLines($"{Environment.CurrentDirectory}\\input.txt");
        char[,] matrix = new char[input[0].Length, input.Length];
        List<Antenna> uniqueAntennae = new List<Antenna>();
        List<Vector> antinodePositions = new List<Vector>();
        var total = 0;
        char emptySpace = '.';
        char antinode = '#'; // Commented out because we don't need to change the matrix just need to do the maths.
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = input[i][j];
                if (matrix[i, j] == emptySpace)
                {
                    continue;
                }
                // it is an antenna
                if (!AntennaExists(uniqueAntennae, matrix[i,j]))
                {
                    uniqueAntennae.Add(new Antenna(){ Character = matrix[i, j], Position = new List<Vector>()});
                    uniqueAntennae[uniqueAntennae.Count - 1].Position.Add(new Vector() { X = i, Y = j }); // YES                    
                }
                else
                {
                    foreach (var antenna in uniqueAntennae)
                    {
                        if (antenna.Character == matrix[i, j])
                        {
                            antenna.Position.Add(new Vector() { X = i, Y = j });
                        }
                    }
                }
             }
        }

        Console.WriteLine($"Count of unique: {uniqueAntennae.Count}");
        Console.WriteLine($"First Charater is {uniqueAntennae[0].Character} it has {uniqueAntennae[0].Position.Count} positions.");
        Console.WriteLine($"First Charater is {uniqueAntennae[1].Character} it has {uniqueAntennae[1].Position.Count} positions.");
        
        // We have a list of Antennae instances
        
        // Loop through the vectors for the antennae, we have to do 2 loops to get all combinations.

        foreach (var ant in uniqueAntennae)
        {
            // For each unique antenna we need to compare their instances and amend the matrix' positions to add antinodes
            for (var a = 0; a < ant.Position.Count; a++)
            {
                var masterAntennaPos = ant.Position[a]; // Our Original
                // A is the position we're currently looking at, for each one we need to get the difference in vector
                // and see if that difference in vector takes us out of the matrix.
                // We need a function that checks if we're out of the matrix 
                // We need a function that reverses a vector
                // If it doesn't take us out of the matrix we need to add a value to our total. 
                
                // Formula for finding the vector to another antenna: compared antenna pos - original antenna pos

                for (var b = 0; b < ant.Position.Count; b++)
                {
                    if (b == a)
                    {
                        continue;
                    }
                    var comparedAntennaPos = ant.Position[b];
                    // get vector
                    var differenceVector = new Vector(){ X = comparedAntennaPos.X - masterAntennaPos.X, Y = comparedAntennaPos.Y - masterAntennaPos.Y };
                    var antinodePosition = new Vector(){ X = comparedAntennaPos.X + differenceVector.X, Y = comparedAntennaPos.Y + differenceVector.Y};

                    if (!IsOutOfBounds(matrix, antinodePosition.X, antinodePosition.Y))
                    {
                        bool antAlreadyExists = false;
                        foreach (var pos in antinodePositions)
                        {
                            if (pos.X == antinodePosition.X && pos.Y == antinodePosition.Y)
                            {
                                Console.WriteLine($"An Antinode is already here");
                                antAlreadyExists = true;
                                break;
                            }
                        }
                        if (antAlreadyExists) { continue; } 
                        total++;
                        antinodePositions.Add(antinodePosition);
                        Console.WriteLine($"Original Pos {ant.Position[a].X}, {ant.Position[a].Y} | Compared Pos {ant.Position[b].X}, {ant.Position[b].Y} | Position of the Antinode: {antinodePosition.X}, {antinodePosition.Y} | Total: {total}");
                        matrix[antinodePosition.X, antinodePosition.Y] = '#';
                        // So we've got (for example) an A with multiple antinodes under it and we shouldn't.
                        if (matrix[antinodePosition.X, antinodePosition.Y] != emptySpace)
                        {
                            continue;
                        } 
                    }
                }
            }
        }
        


        
        // Output the matrix
        for (var x = 0; x < matrix.GetLength(0); x++)
        {
            for (var y = 0; y < matrix.GetLength(1); y++)
            {
                Console.Write(matrix[x, y]);
                if (y == matrix.GetLength(1) -1 ) {Console.WriteLine("");}
            }
        }
        Console.WriteLine(total);
    }

    static bool AntennaExists(List<Antenna> uniqueAntennae, char character)
    {

        foreach (var antenna in uniqueAntennae)
        {
            if (antenna.Character == character)
            {
                return true;
            }
        }
        return false;
    }
    
    
    // We need a function that checks if we're out of the matrix 
    static bool IsOutOfBounds(char[,] matrix, int x, int y)
    {
        if (x > (matrix.GetLength(0)-1) || y > (matrix.GetLength(1)-1) || (x < 0 || y < 0))
        {
            return true;
        }
        return false;
    }
}