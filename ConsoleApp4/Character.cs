namespace ConsoleApp3;

public class Character
{
    public string Name { get; }
    public string Role { get; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    public CharacterState State { get; set; }
    
    public Character(string name, string role, int lvl, int hp = 100, int gold = 0, CharacterState state = CharacterState.Active)
    {
        Name = name;
        Role = role;
        Level = lvl;
        Health = hp;
        Gold = gold;
        State = state;
    }
}