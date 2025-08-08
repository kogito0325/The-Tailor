using UnityEngine;
using UnityEngine.UI;


public class BossUI : MonoBehaviour
{
    [SerializeField] private Image hpGazeIMG;
    [SerializeField] private MonoBoss boss;

    private void Start()
    {
        hpGazeIMG.fillAmount = boss.Hp / boss.BossData.hp;
    }

    private void Update()
    {
        hpGazeIMG.fillAmount = boss.Hp / boss.BossData.hp;
    }
}
