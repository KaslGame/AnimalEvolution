using UnityEngine;

namespace CharacterSystem
{
    [CreateAssetMenu(fileName = "New character", menuName = "Charater/Create new Character", order = 51)]
    public class CharacterData : ScriptableObject
    {
        public Mesh Mesh;
        public Material Material;
        public Vector3 SizeCollider;
        public int MinLevel;
    }
}
