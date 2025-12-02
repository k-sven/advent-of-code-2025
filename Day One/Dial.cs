using System.Runtime.InteropServices.JavaScript;

namespace Day_One;

public class Dial
{
    /// <summary>
    /// Current position of the dial. If it hits above 99, it should go down to 0 and vice versa.
    /// </summary>
    public int CurrentPosition { get; private set; } = 50;
    /// <summary>
    /// Resets the dial to 50.
    /// </summary>
    public void ResetDial()
    {
        this.CurrentPosition = 50;
    }
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
    /// Turns the dial in the given direction and given number.
    /// </summary>
    /// <param name="pos">A string containing the direction (R or L) and the number to turn the dial by.</param>
    /// <example><code>TurnDialByPosition("R20");</code> is R20, the dial is to be turned 20 to the right.</example>
    /// <returns>Returns the total count of clicks when the dial has gotten to 0 or passed it.</returns>
    /// <exception cref="InvalidDataException"></exception>
    public int TurnDialByPositionAndCountClicks(string pos)
    {
        string direction = pos[0].ToString().ToUpper();
        int distance = int.Parse(pos.Substring(1));
        switch (direction)
        {
            case "R":
                return TurnDialCountClicks(distance);
            case "L":
                return TurnDialCountClicks(-distance);
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
    /// <summary>
    /// Turns the dial by the given position
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>Returns the total amount of clicks</returns>
    private int TurnDialCountClicks(int pos)
    {
        int countedClicks = 0;
        if (pos > 0) // Turn clockwise
        {
            countedClicks = (CurrentPosition + pos) / 100;
        }
        else if (pos < 0) // Turn counter-clockwise
        {
            countedClicks = -pos / 100;
            int remaining = -pos % 100;
            if (CurrentPosition > 0 && CurrentPosition <= remaining)
            {
                countedClicks++;
            }
        }
        int addedPosition = CurrentPosition + pos;
        Console.WriteLine("Counted Clicks: {0}", countedClicks);
        int newPosition = (addedPosition % 100 + 100) % 100;
        CurrentPosition = newPosition;
        Console.WriteLine("Dialed to {0}", CurrentPosition);
        return countedClicks;
    }
}