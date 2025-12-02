namespace Day_One;

class Program
{
    static void Main(string[] args)
    {
        // string[] puzzleInput =
        // {
        //     "L68",
        //     "L30",
        //     "R48",
        //     "L5",
        //     "R60",
        //     "L55",
        //     "L1",
        //     "L99",
        //     "R14",
        //     "L82"
        // };
        string[] puzzleInput = File.ReadAllLines("input.txt");
        Dial dial = new Dial();
        int dialReachedZero = 0;
        foreach (string input in puzzleInput)
        {
            dial.TurnDialByPosition(input);
            if (dial.CurrentPosition == 0)
            {
                dialReachedZero++;
                Console.WriteLine("Dial reached zero");
            }
        }
        Console.WriteLine(dialReachedZero);
    }
}