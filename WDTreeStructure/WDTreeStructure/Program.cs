using WDTreeStructure;

class Program
{
    static void Main()
    {
        var tree = new Tree();
        tree.BuildFromFile("numbersfortree.txt");
        tree.Display();
    }
}