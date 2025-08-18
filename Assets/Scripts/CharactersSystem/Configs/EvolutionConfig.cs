using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    [CreateAssetMenu(fileName = "New evolution config", menuName = "Character/New config", order = 51)]
    public class EvolutionConfig : ScriptableObject
    {
        public List<CharacterData> Charaters;

        private void OnValidate()
        {
            Charaters.Sort((firstCharacter, secondCharacter) => firstCharacter.MinLevel.CompareTo(secondCharacter.MinLevel));
        }

        public CharacterData GetCharacterByLevel(int level)
        {
            CharacterData result = null;

            for (int i = 0; i < Charaters.Count; i++)
            {
                if (level >= Charaters[i].MinLevel)
                    result = Charaters[i];
                else
                    break;
            }

            return result;
        }

        public CharacterData GetNextCharacter(int level)
        {
            for (int i = 0; i < Charaters.Count; i++)
            {
                if (Charaters[i].MinLevel > level)
                    return Charaters[i];
            }

            return null;
        }
    }
}