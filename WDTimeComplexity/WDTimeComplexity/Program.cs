using WDTimeComplexity;

public class Program
{
    public static void Main(string[] args)
    {
        TimeComplexityExamples examples = new TimeComplexityExamples();

        int[] arr = { 1, 2, 3, 4, 5, };

        Console.WriteLine("O(1) - First Element: " + examples.GetFirstElement(arr));

        Console.WriteLine("O(n) - Printing Elements:");
        examples.PrintElements(arr);

        Console.WriteLine("O(n2) - Printing Pairs:");
        examples.PrintPairs(arr);
    }
}
