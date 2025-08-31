using Map;
using UnityEngine;

[CreateAssetMenu(fileName = "New paid map", menuName = "Shop/Create new paid map", order = 53)]
public class PaidMap : ScriptableObject
{
    public Sprite Icon;
    public NameScene MapName;
    public int Price;
}
