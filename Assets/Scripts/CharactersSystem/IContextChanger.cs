using System;

namespace CharacterSystem
{
    public interface IContextChanger
    {
        event Action<CharacterContext> ContextChanged;
    }
}