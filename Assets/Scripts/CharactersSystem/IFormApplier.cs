using PlayerScripts;

namespace CharacterSystem
{
    public interface IFormApplier
    {
        CharacterContext ApplyForm(CharacterData character);
    }
}