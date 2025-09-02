using UnityEngine;

public class Projectile : Monster
{
    public override void Hit(int damage = 1)
    {
        base.Hit(damage);
        GetComponent<Animator>().Play("Fly");
    }
}
