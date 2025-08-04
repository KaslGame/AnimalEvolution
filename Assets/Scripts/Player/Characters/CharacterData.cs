using UnityEngine;

namespace PlayerScripts
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Create new character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public Player _prefab;
        public int MaxLevel;
    }
}
