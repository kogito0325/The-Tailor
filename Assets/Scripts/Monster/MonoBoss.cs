using UnityEngine;

public class MonoBoss : MonoBehaviour
{
    [field: SerializeField] public BossData BossData {  get; private set; }
    
    public float Hp {  get; private set; }


    private void Start()
    {
        Hp = BossData.hp;
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
    }
}
