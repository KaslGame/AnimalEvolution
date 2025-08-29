using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "New map config", menuName = "Map/Create new map", order = 52)]
    public class MapConfig : ScriptableObject
    {
        public Sprite Icon;
        public NameScene MapName;
        public int Level;
        public bool PaidMap;
    }
}
