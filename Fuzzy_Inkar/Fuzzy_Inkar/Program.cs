namespace Fuzzy_Inkar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Dict_A (e.g., key1:0.5,key2:0.3): ");
            var dictA = ParseInput(Console.ReadLine());

            var result = SubtractFromOne(dictA);

            Console.Write("Result after subtracting from 1:");
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }

        static Dictionary<string, double> SubtractFromOne(Dictionary<string, double> dictA)
        {
            var result = new Dictionary<string, double>();

            foreach (var kvp in dictA)
            {
                // Subtract the value from 1 and round to 2 decimal places
                result[kvp.Key] = Math.Round(1 - kvp.Value, 2);
            }

            return result;
        }

        static Dictionary<string, double> ParseInput(string input)
        {
            var result = new Dictionary<string, double>();
            var entries = input.Split(',');

            foreach (var entry in entries)
            {
                var keyValue = entry.Split(':');
                result[keyValue[0].Trim()] = double.Parse(keyValue[1]);
            }

            return result;
        }
    }
}
