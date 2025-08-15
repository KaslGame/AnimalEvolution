using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    [CreateAssetMenu(fileName = "New evolution config", menuName = "Character/New config", order = 51)]
    public class EvolutionConfig : ScriptableObject
    {
        public List<CharacterData> _charaters;

        private void OnValidate()
        {
            _charaters.Sort((firstCharacter, secondCharacter) => firstCharacter.MinLevel.CompareTo(secondCharacter.MinLevel));
        }

        public CharacterData GetCharacterByLevel(int level)
        {
            CharacterData result = null;

            for (int i = 0; i < _charaters.Count; i++)
            {
                if (level >= _charaters[i].MinLevel)
                    result = _charaters[i];
                else
                    break;
            }

            return result;
        }

        public CharacterData GetNextCharacter(int level)
        {
            for (int i = 0; i < _charaters.Count; i++)
            {
                if (_charaters[i].MinLevel > level)
                    return _charaters[i];
            }

            return null;
        }
    }
}