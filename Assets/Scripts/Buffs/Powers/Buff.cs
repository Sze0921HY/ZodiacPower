using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Scriptable Objects/BuffParent")]
public class Buff : ScriptableObject
{

    public BuffEnum CurrentBuff;

    public string buffDescription;

    public bool isContinue;

    public Sprite sprite;
    public virtual void Apply(CarStats stats) { }
}
