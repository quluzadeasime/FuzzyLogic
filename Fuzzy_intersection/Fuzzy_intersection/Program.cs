

namespace Fuzzy_intersection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Dict_A (e.g., key1:0.5,key2:0.3): ");
            var dictA = ParseInput(Console.ReadLine());
            Console.WriteLine("Enter Dict_B (e.g., key1:0.6,key3:0.8): ");
            var dictB = ParseInput(Console.ReadLine());

            var result = FuzzyIntersection(dictA, dictB);

            Console.WriteLine("A∩B:");
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }

        static Dictionary<string, double> FuzzyIntersection(Dictionary<string, double> dictA, Dictionary<string, double> dictB)
        {
            var result = new Dictionary<string, double>();

            // Find common keys between both dictionaries
            var commonKeys = dictA.Keys.Intersect(dictB.Keys);

            foreach (var key in commonKeys)
            {
                // Get the values for the common key
                double valueA = dictA[key];
                double valueB = dictB[key];

                // Take the minimum of the two values
                result[key] = Math.Min(valueA, valueB);
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
