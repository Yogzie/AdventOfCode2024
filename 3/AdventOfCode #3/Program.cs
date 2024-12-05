using System.Text.RegularExpressions;

namespace AdventOfCode__3
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string memory = File.OpenText(Environment.CurrentDirectory + "/input.txt").ReadToEnd();
            string testString;

            Regex regExMul = new Regex(@"^mul\([0-9]{1,3},[0-9]{1,3}\).*");

            Regex regExDo = new Regex(@"^do\(\).*");

            Regex regExDont = new Regex(@"^don't\(\).*");

            
            int index = 0; 
            int maxLen = 12; // This is the max length a string can be according to the rules
            int total = 0;

            bool ProcessMul = true;
            foreach (var c in memory)
            {
                if ((Math.Abs(index - memory.Length)) < maxLen) { maxLen = memory.Length - index; }
                testString = memory.Substring(index, maxLen);

                if (regExDont.IsMatch(testString)) { ProcessMul = false; }

                if (regExDo.IsMatch(testString)) { ProcessMul = true; }

                // This matches Mul and will be processed
                if (regExMul.IsMatch(testString) && ProcessMul)
                {
                    total = total + MultiplyMul(testString);
                }
                index++;
            }

            Console.WriteLine(total);

        }
        public static int MultiplyMul(string testString)
        {
            testString = testString.Split(')')[0];
            int num1;
            int num2;

            testString = testString.Split('(')[1];
            num1 = Convert.ToInt32(testString.Split(',')[0]);
            num2 = Convert.ToInt32(testString.Split(',')[1]);

            return (num1 * num2);
        }
    }
}