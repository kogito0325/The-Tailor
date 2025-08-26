using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoPlayerAttackCollision : MonoBehaviour
{
    private List<GameObject> _collisionObjects;

    private void Start()
    {
        _collisionObjects = new List<GameObject>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IHittable hittable))
        {
            _collisionObjects.Add(collision.gameObject);
        }
    }

    private void Update()
    {
        if (_collisionObjects.Count > 0)
        {
            //_collisionObjects.OrderBy(x => x.transform.position.x).ToList()[0].GetComponent<IHittable>().Hit(1);
            _collisionObjects.OrderBy(x => x.transform.position.x).First().GetComponent<IHittable>().Hit(1);
            _collisionObjects.Clear();
            gameObject.SetActive(false);
        }
    }

    public void ActivateAttackRange(bool flag)
    {
        gameObject.SetActive(flag);
    }

}
