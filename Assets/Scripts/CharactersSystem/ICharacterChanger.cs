using System;

namespace CharacterSystem
{
    public interface ICharacterChanger
    {
        event Action<CharacterData, CharacterData> CharacterChanged;
    }
}