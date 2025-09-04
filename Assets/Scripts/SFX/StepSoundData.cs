using UnityEngine;

[CreateAssetMenu(fileName = "New sound data", menuName = "Character/Create new step sound data", order = 51)]
public class StepSoundData : ScriptableObject
{
    public AudioClip[] Sounds;
}
