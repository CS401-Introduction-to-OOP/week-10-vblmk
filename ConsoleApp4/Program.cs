using System;
using System.Linq;
using ConsoleApp3;

var party = new Party();
party.AddCharacter(new Character("thor", "warrior", 10, 100, 50, CharacterState.Active));
party.AddCharacter(new Character("spiderman", "archer", 9, 80, 100, CharacterState.Active));
party.AddCharacter(new Character("superman", "warrior", 9, 45, 150, CharacterState.Wounded));
party.AddCharacter(new Character("batman", "warrior", 8, 0, 10, CharacterState.Dead));
party.AddCharacter(new Character("joker", "mage", 20, 100, 500, CharacterState.Active));

var eventLog = new EventLog();
eventLog.AddEvent(new Event(1, "goblin ambush", EventType.Combat, "all: hp -10"));
eventLog.AddEvent(new Event(2, "found a hidden chest", EventType.Loot, "aragorn: gold +50"));
eventLog.AddEvent(new Event(3, "stepped on poison spikes", EventType.Trap, "gimli: hp -20"));
eventLog.AddEvent(new Event(4, "short rest by the campfire", EventType.Healing, "all: hp +15"));
eventLog.AddEvent(new Event(5, "battle with a troll", EventType.Combat, "boromir: hp -100"));

Console.WriteLine();

Console.WriteLine("\nall characters in the party");
foreach (var character in party)
{
    Console.WriteLine($"{character.Role} {character.Name} - lvl: {character.Level}, hp: {character.Health}, gold: {character.Gold}, state: {character.State}");
}

Console.WriteLine("\nall events in the log");
foreach (var ev in eventLog)
{
    Console.WriteLine($"turn {ev.MoveNumber}: {ev.Description} ({ev.Type}) -> {ev.CharsChange}");
}


Console.WriteLine();

Console.WriteLine("\nactive characters");
foreach (var activeChar in party.GetActiveCharacters())
{
    Console.WriteLine($"{activeChar.Name} is ready for battle");
}

Console.WriteLine("\nwounded characters (hp < 100)");
foreach (var woundedChar in party.GetWoundedCharacters(100))
{
    Console.WriteLine($"{woundedChar.Name} needs healing (hp: {woundedChar.Health})");
}

Console.WriteLine("\ncombat events");
foreach (var combatEvent in eventLog.GetEventsByType(EventType.Combat))
{
    Console.WriteLine($"turn {combatEvent.MoveNumber}: {combatEvent.Description}");
}

Console.WriteLine("");

var highLevelChars = party.Where(c => c.Level > 8);
Console.WriteLine("\ncharacters above level 8");
foreach (var c in highLevelChars) Console.WriteLine($"{c.Name} (level {c.Level})");

var sortedByHp = party.OrderBy(c => c.Health);
Console.WriteLine("\nsorting by hp ");
foreach (var c in sortedByHp) 
    Console.WriteLine($"{c.Name}: {c.Health} hp");

var characterNames = party.Select(c => c.Name);
Console.WriteLine("\nlist of party names");
Console.WriteLine(string.Join(", ", characterNames));

int woundedCount = party.Count(c => c.State == CharacterState.Wounded);
double averageLevel = party.Average(c => c.Level);
int maxGold = party.Max(c => c.Gold);
var richestChar = party.First(c => c.Gold == maxGold);

Console.WriteLine();
Console.WriteLine($"number of wounded: {woundedCount}");
Console.WriteLine($"average party level: {averageLevel:f1}");
Console.WriteLine($"richest character: {richestChar.Name} ({richestChar.Gold} gold)");
