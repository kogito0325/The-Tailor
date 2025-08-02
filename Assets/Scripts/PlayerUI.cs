using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private MonoPlayer player;
    [SerializeField] private GameObject[] hpObjects;


    private void Start()
    {
        foreach (var hp in hpObjects) hp.SetActive(false);
        for (int i = 0; i < player.Hp; i++)
        {
            hpObjects[i].SetActive(true);
        }
    }

    private void Update()
    {
        for (int i = 0; i < player.Hp; i++)
        {
            hpObjects[i].SetActive(true);
        }
        for (int i = player.Hp; i < hpObjects.Length; i++)
        {
            hpObjects[i].SetActive(false);
        }
    }
}
