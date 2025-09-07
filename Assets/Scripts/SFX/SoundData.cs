using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New sound data", menuName = "Sound/Create new sound data", order = 54)]
public class SoundData : ScriptableObject
{
    public List<AudioClip> Sounds;
}
