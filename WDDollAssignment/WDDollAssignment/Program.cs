using System;
using System.Collections.Generic;

public class MatryoshkaDollSet
{
    public static void Main()
    {
        // A single set of 24 nested dolls where "Doll24" is the largest and "Doll1" is the smallest
        List<string> dollSet = new List<string>()
        {
            "Doll24", "Doll23", "Doll22", "Doll21", "Doll20", "Doll19", "Doll18", "Doll17",
            "Doll16", "Doll15", "Doll14", "Doll13", "Doll12", "Doll11", "Doll10", "Doll9",
            "SignedDoll", "Doll8", "Doll7", "Doll6", "Doll5", "Doll4", "Doll3", "Doll2", "Doll1"
        };

        // Part 1: Count all dolls in the set
        int totalDolls = CountAllDolls(dollSet);
        Console.WriteLine("Total number of dolls: " + totalDolls);

        // Part 2: Line up dolls (from largest to smallest, which they already are)
        List<string> sortedDolls = LineUpDolls(dollSet);
        Console.WriteLine("Dolls arranged from largest to smallest:");
        foreach (string doll in sortedDolls)
        {
            Console.WriteLine(doll); // Output each doll on a new line
        }

        // Part 3: Find the unique signed doll
        string signedDoll = FindUniqueDoll(dollSet);
        if (signedDoll != null)
        {
            Console.WriteLine("Found the signed doll: " + signedDoll);
        }
        else
        {
            Console.WriteLine("No signed doll found.");
        }
    }

    // Part 1: Count all dolls in the set
    public static int CountAllDolls(List<string> set)
    {
        return set.Count;  // Return the total count of dolls in the set
    }

    // Part 2: Line up dolls (sorting from largest to smallest, which is already done)
    public static List<string> LineUpDolls(List<string> set)
    {
        // Since the dolls are already arranged from largest to smallest, no sorting needed.
        return set;
    }

    // Part 3: Find the unique doll with an artist's signature
    public static string FindUniqueDoll(List<string> set)
    {
        foreach (string doll in set)
        {
            if (doll == "SignedDoll")  // Look for the signed doll
            {
                return doll;  // Return the signed doll if found
            }
        }
        return null;  // Return null if no signed doll is found
    }
}


