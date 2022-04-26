using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusCondition { None, Asleep, Paralyzed, Slow }
public class Effect
{
    // TODO: Implement

}

[CreateAssetMenu(fileName = "New Stats", menuName = "Player/Stats")]
public class Stats : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public PlayerType playerType = PlayerType.Fighter;
    public IntVariable level;
    public FloatVariable strength;
    public FloatVariable agility;
    public FloatVariable magicPower;
    public IntVariable gold;
    public IntVariable xp;
    public FloatVariable currentMagic;
    public FloatVariable currentHealth;
    public FloatVariable maxMagic;
    public FloatVariable maxHealth;
    public StatusCondition condition;
    public Effect effect;
}
