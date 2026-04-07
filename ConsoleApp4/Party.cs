namespace ConsoleApp3;

using System.Collections;
using System.Collections.Generic;

public class Party : IEnumerable<Character>
{
    private List<Character> _characters = new List<Character>();

    public void AddCharacter(Character character)
    {
        _characters.Add(character);
    }
    
    public IEnumerator<Character> GetEnumerator()
    {
        foreach (var character in _characters)
        {
            yield return character;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public IEnumerable<Character> GetActiveCharacters()
    {
        foreach (var character in _characters)
        {
            if (character.State == CharacterState.Active)
            {
                yield return character;
            }
        }
    }
    
    public IEnumerable<Character> GetWoundedCharacters(int maxHp)
    {
        foreach (var character in _characters)
        {
            if (character.Health < maxHp)
            {
                yield return character;
            }
        }
    }
}