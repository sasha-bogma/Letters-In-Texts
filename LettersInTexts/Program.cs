using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LettersInTexts
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateStatiscstics(@"../../texts/remark.txt");
            CalculateStatiscstics(@"../../texts/bible.txt");
            CalculateStatiscstics(@"../../texts/r-prog.txt");
        }

        static void CalculateStatiscstics(string path)
        {
            Dictionary<char, int> alphabetDict = InitAlphabetDictionary();
            InitAlphabetDictionary();

            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                CountLettersInLine(line, alphabetDict);
            }
            file.Close();

            Console.WriteLine("Statistics for " + path);
            PrintStatistics(alphabetDict);
            Console.WriteLine("`````````````````````````````````````````````````````````````````````````");

        }

        static Dictionary<char, int> InitAlphabetDictionary()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (char letter = 'а'; letter <= 'я'; letter++)
            {
                dict.Add(letter, 0);
            }
            dict.Add('ё', 0);
            return dict;
        }

        static void CountLettersInLine(string line, Dictionary<char, int> dict)
        {
            line = line.ToLower();
            foreach (char letter in line)
                if (dict.ContainsKey(letter))
                    dict[letter]++;
        }

        static void PrintStatistics(Dictionary<char, int> dict)
        {
            int totalLetters = dict.Values.Sum();

            foreach (var item in dict)
            {
                double percent = Math.Round(((double)item.Value / totalLetters) * 100, 2);
                Console.Write(item.Key + " ");
                for (double i = 0; i <= percent; i+= 0.2)
                    Console.Write("=");
                Console.WriteLine(" " + percent + " %");
            }
        }
    }
}
