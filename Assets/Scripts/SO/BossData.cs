using UnityEngine;

[CreateAssetMenu(fileName = "NewBossData", menuName = "Scriptable Objects/BossData")]
public class BossData : ScriptableObject
{
    [Header("체력")] public float hp;
}
