using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData", menuName = "Scriptable Objects/MonsterData")]
public class MonsterData : ScriptableObject
{
    [Header("체력")] public int hp;
    [Header("속도")] public float speed;
}