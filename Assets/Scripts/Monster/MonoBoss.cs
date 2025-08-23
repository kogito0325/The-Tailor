using System.Collections;
using UnityEngine;

public class MonoBoss : MonoBehaviour
{
    [field: SerializeField] public BossData BossData {  get; private set; }
    
    public float Hp {  get; private set; }
    private int _spawnStream;

    Coroutine _spawnCoroutine;

    private void Start()
    {
        Hp = BossData.hp;
        _spawnStream = 0;
    }

    private void Update()
    {
        if(_spawnCoroutine == null && _spawnStream > 0)
        {
            _spawnCoroutine = StartCoroutine(IESpawnMonster());
        }
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
    }
    
    public void AddStream()
    {
        _spawnStream++;
    }

    private IEnumerator IESpawnMonster()
    {
        _spawnStream--;
        GetComponent<Animator>().Play("SpawnMonster");
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2);
        GetComponent<Animator>().Play("Idle");
        _spawnCoroutine = null;
    }
}
