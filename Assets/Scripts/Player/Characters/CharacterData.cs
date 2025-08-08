using UnityEngine;

namespace PlayerScripts
{
    [CreateAssetMenu(fileName = "New character", menuName = "Characters/Create new character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public Player _prefab;
        public int _minLevel;
    }
}
