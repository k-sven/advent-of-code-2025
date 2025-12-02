namespace Day_One;

public class Dial
{
    /// <summary>
    /// Current position of the dial. If it hits above 99, it should go down to 0 and vice versa.
    /// </summary>
    public int CurrentPosition { get; private set; } = 50;

    /// <summary>
    /// Turns the dial in the given direction and given number.
    /// </summary>
    /// <param name="pos">A string containing the direction (R or L) and the number to turn the dial by.</param>
    /// <example><code>TurnDialByPosition("R20");</code> is R20, the dial is to be turned 20 to the right.</example>
    public void TurnDialByPosition(string pos)
    {
        string direction = pos[0].ToString().ToUpper();
        int distance = int.Parse(pos.Substring(1));
        switch (direction)
        {
            case "R":
                TurnDial(distance);
                break;
            case "L":
                TurnDial(-distance);
                break;
            default:
                throw new InvalidDataException("Invalid direction");
        }
    }
    /// <summary>
    /// Turns the dial by the given position
    /// </summary>
    /// <param name="pos"></param>
    private void TurnDial(int pos)
    {
        // C# does not use 'true' modulo as it does not truncate into negative thus needing another formular. 
        // ((value % divisor) + divisor) % divisor
        // Meaning the value does get pushed into the positives by adding the devisor. If it is above the devisor, it gets truncated back into below the devisor.
        int newPosition = ((CurrentPosition + pos) % 100 + 100) % 100;
        CurrentPosition = newPosition;
        Console.WriteLine("Dialed to {0}", CurrentPosition);
    }
}