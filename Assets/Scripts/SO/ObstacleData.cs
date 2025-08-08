using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacleData", menuName = "Scriptable Objects/ObstacleData")]


public class ObstacleData : ScriptableObject
{
    [Header("속도")] public float speed;
}