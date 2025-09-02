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
        if (Hp <= 0)
            GameManager.Instance.MoveScene("EndScene");
    }
    
    public void AddStream()
    {
        _spawnStream++;
    }

    private IEnumerator IESpawnMonster()
    {
        _spawnStream--;
        //GetComponent<Animator>().Play("SpawnMonster");
        GetComponent<Animator>().SetTrigger("Spawn");
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 40);
        GetComponent<Animator>().SetTrigger("Idle");
        //GetComponent<Animator>().Play("Idle");
        _spawnCoroutine = null;
    }
}
