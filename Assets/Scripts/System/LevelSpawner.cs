using System.Collections;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [Header("레벨 리스트"), SerializeField] private GameObject[] Levels;
    [Header("생성주기(단위: 초)"), SerializeField] private float interval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine(interval));
    }

    private GameObject ChoiceLevel()
    {
        int randomIdx = Random.Range(0, Levels.Length);
        return Levels[randomIdx];
    }

    private void SpawnLevel(GameObject level)
    {
        Instantiate(level, transform);
    }

    private IEnumerator SpawnRoutine(float interval)
    {
        while (true)
        {
            GameObject level = ChoiceLevel();
            SpawnLevel(level);

            yield return new WaitForSeconds(interval);
        }
    }
}
