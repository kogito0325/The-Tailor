using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("체력")] public int hp;
    [Header("점프력")] public float jumpPower;
    [Header("무적시간")] public float evasionTime;
}
