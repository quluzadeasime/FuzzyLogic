using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuzzy;


class Program
    {
        static Dictionary<string, double> FuzzyUnion(Dictionary<string, double> dictA, Dictionary<string, double> dictB)
        {
            var result = new Dictionary<string, double>();

            // Combine all unique keys from both dictionaries
            var allKeys = new HashSet<string>(dictA.Keys.Concat(dictB.Keys));

            foreach (var key in allKeys)
            {
                // Get the values, defaulting to 0 if the key doesn't exist
                double valueA = dictA.ContainsKey(key) ? dictA[key] : 0;
                double valueB = dictB.ContainsKey(key) ? dictB[key] : 0;

                // Take the maximum of the two values
                result[key] = Math.Max(valueA, valueB);
            }

            return result;
        }

        static void Main(string[] args)
        {
            // Example usage
            Console.Write("Enter Dict_A (e.g., key1:0.5,key2:0.3): ");
            var dictA = ParseInput(Console.ReadLine());
            Console.Write("Enter Dict_B (e.g., key1:0.6,key3:0.8): ");
            var dictB = ParseInput(Console.ReadLine());

            var result = FuzzyUnion(dictA, dictB);

            Console.WriteLine("A∪B:");
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
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



