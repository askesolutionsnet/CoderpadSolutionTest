using System;
using System.Collections.Generic;
using System.IO;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {

        ////Should program take user input for file path instead giving hard code
        // if(args.Length == 0)
        // {

        //     Console.WriteLine("Please provide the path to the input file as an argument.");
        //     return;
        // }
        //string filePath = args[0];  

        string filePath = "C:\\Users\\askad\\OneDrive\\My Documents\\Visual Studio 2022\\Test\\TradeTeqTest\\CoderpadSolutionTest\\CoderpadSolutionTest\\example1.txt";
        try
        {
            List<List<string>> anagramGroups = GroupAnagrams(filePath);
            PrintAnagramGroups(anagramGroups);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static List<List<string>> GroupAnagrams(string filePath)
    {
        var anagramGroups = new List<List<string>>();
        var anagramDict = new Dictionary<string, List<string>>();

        using (var reader = new StreamReader(filePath))
        {
            if (reader != null)
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(word))
                        break;

                    //Console.WriteLine($"I am reading:{word}");
                    string sortedWord = SortString(word);

                    if (!anagramDict.ContainsKey(sortedWord))
                    {
                        anagramDict[sortedWord] = new List<string>();
                        anagramGroups.Add(anagramDict[sortedWord]);
                    }

                    anagramDict[sortedWord].Add(word);
                }
            }
            else
                Console.WriteLine("File is empty");
        }

        return anagramGroups;

    }

    static string SortString(string input)
    {
        char[] characters = input.ToCharArray();
        Array.Sort(characters);
        return new string(characters);
    }

    static void PrintAnagramGroups(List<List<string>> anagramGroups)
    {
        foreach (var group in anagramGroups)
        {
            Console.WriteLine(string.Join(",", group));
        }
    }

}
