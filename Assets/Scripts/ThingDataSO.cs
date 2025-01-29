using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Thing/Data", fileName = "ThingDataSO")]
public class ThingDataSO : ScriptableObject
{
    public int price;
    public Sprite thingSprite;
    public bool isSharp;
    [MaxValue(1f)] public float probability;

}
