using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float turn_speed;
    public float move_speed;
    public Rigidbody2D rb;
    private Vector2 direction_princess;
    private Vector2 direction_player;
    public int health = 100;
    public GameObject DeathEffect;
    public GameObject GetHitEffect;
    public GameObject CoinThing;
    public Transform treePOS;
    public Transform playerPOS;

    void Start()
    {
        treePOS = GameObject.FindGameObjectWithTag("Tree").transform;
        playerPOS = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("enemyGetHit");
        GameObject Blood = Instantiate(GetHitEffect, transform.position, Quaternion.identity);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        Destroy(Blood, 5f);
    }
    void Die()
    {
        GameObject coin1 = Instantiate(CoinThing, transform.position, Quaternion.identity);
        GameObject coin2 = Instantiate(CoinThing, transform.position, Quaternion.identity);
        GameObject coin3 = Instantiate(CoinThing, transform.position, Quaternion.identity);
        GameObject dea = Instantiate(DeathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
        Destroy(dea,3f);
    }

    void Update()
    {
        direction_princess = treePOS.position - transform.position;
        direction_player = playerPOS.position - transform.position;
        if ((direction_princess.x * direction_princess.x) + (direction_princess.y * direction_princess.y) < (direction_player.x * direction_player.x) + (direction_player.y * direction_player.y))
        {
            float angle = Mathf.Atan2(direction_princess.y, direction_princess.x) * Mathf.Rad2Deg + 85;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turn_speed * Time.deltaTime);
        }
        else
        {
            float angle = Mathf.Atan2(direction_player.y, direction_player.x) * Mathf.Rad2Deg + 85;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turn_speed * Time.deltaTime);
        }

    }
    void FixedUpdate()
    {
        if ((direction_princess.x * direction_princess.x) + (direction_princess.y * direction_princess.y) < (direction_player.x * direction_player.x) + (direction_player.y * direction_player.y))
        {
           transform.position = Vector2.MoveTowards(transform.position, treePOS.position, move_speed * Time.fixedDeltaTime);
        }
        else { transform.position = Vector2.MoveTowards(transform.position,playerPOS.position,move_speed * Time.fixedDeltaTime); }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.TakeDamage(25);
            
        }
            TreeScript tree = collision.gameObject.GetComponent<TreeScript>();
        if (tree != null)
        {
            tree.TakeDamage(20);
        }
    }
//    IEnumerator DoDamage(GameObject thing)
//    {
//        yield return new WaitForSeconds(1.5f);
//        if (thing != null)
//        {
//            thing.TakeDamage(25);
//            yield return new WaitForSeconds(1.5f);
//        }
//
//
//    }
}
