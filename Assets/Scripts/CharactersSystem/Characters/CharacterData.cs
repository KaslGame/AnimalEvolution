using UnityEngine;
using UnityEngine.UI;

namespace CharacterSystem
{
    [CreateAssetMenu(fileName = "New character", menuName = "Character/Create new Character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public Sprite Icon;
        public GameObject Prefab;
        public int MinLevel;
    }
}
