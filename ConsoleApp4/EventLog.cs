namespace ConsoleApp3;
using System.Collections;
using System.Collections.Generic;

public class EventLog : IEnumerable<Event>
{
    private List<Event> _events = new List<Event>();

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public IEnumerator<Event> GetEnumerator()
    {
        foreach (var ev in _events)
        {
            yield return ev;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public IEnumerable<Event> GetEventsByType(EventType type)
    {
        foreach (var ev in _events)
        {
            if (ev.Type == type)
            {
                yield return ev;
            }
        }
    }
}