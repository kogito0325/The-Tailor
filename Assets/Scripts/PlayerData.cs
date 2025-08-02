using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("ü��")] public int hp;
    [Header("������")] public float jumpPower;
    [Header("�����ð�")] public float evasionTime;
}
