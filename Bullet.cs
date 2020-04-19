using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D (Collision2D collision)
    {
        Destroy(gameObject);
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null){enemy.TakeDamage(damage);}
        SkeletonScript skeleton = collision.gameObject.GetComponent<SkeletonScript>();
        if (skeleton != null) { skeleton.TakeDamage(damage); Debug.Log("Hit Skeleton"); }
    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
