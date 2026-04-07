namespace ConsoleApp3;

public class Event
{
    public int MoveNumber { get; }
    public string Description { get; }
    public EventType Type { get; }
    public string CharsChange { get; }

    public Event(int number, string description, EventType eventType, string charsChange)
    {
        MoveNumber = number;
        Description = description;
        Type = eventType;
        CharsChange = charsChange;
    }
}