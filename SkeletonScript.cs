using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{

    public float turn_speed;
    public float move_speed;
    public Rigidbody2D rb;
    private Vector2 direction_princess;
    private Vector2 direction_player;
    public int health = 100;
    public GameObject DeathEffect;
    public GameObject GetHitEffect;
    public Transform treePOS;
    public Transform playerPOS;
    public Animator animator;
    bool Exploded = false;
    public GameObject CoinThing;

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
        GameObject coin4 = Instantiate(CoinThing, transform.position, Quaternion.identity);
        GameObject coin5 = Instantiate(CoinThing, transform.position, Quaternion.identity);
        GameObject dea = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(dea, 3f);
    }

    void Update()
    {
        direction_princess = treePOS.position - transform.position;
        direction_player = playerPOS.position - transform.position;
        float distance_princess = Vector3.Distance(treePOS.position, transform.position);
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
        // IT WILL GO TO WHICH EVER ONE IS CLOSER ^^^ 
        

    }
    void FixedUpdate()
    {
        if ((direction_princess.x * direction_princess.x) + (direction_princess.y * direction_princess.y) < (direction_player.x * direction_player.x) + (direction_player.y * direction_player.y))
        {
            transform.position = Vector2.MoveTowards(transform.position, treePOS.position, move_speed * Time.fixedDeltaTime);
        }
        else { transform.position = Vector2.MoveTowards(transform.position, playerPOS.position, move_speed * Time.fixedDeltaTime); }
        
    }
    IEnumerator Explode(Vector2 center, float radius)
    {
        animator.SetBool("Explode", true);
        Destroy(gameObject, 2f);
        yield return new WaitForSeconds(1.5f);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            PlayerScript player = hitColliders[i].gameObject.GetComponent<PlayerScript>();
            if (player != null) { player.TakeDamage(50);}
            TreeScript TRE = hitColliders[i].gameObject.GetComponent<TreeScript>();
            if (TRE != null) { TRE.TakeDamage(35);}
            i++;
        }
        SoundManagerScript.PlaySound("skeletonExplode");
        Exploded = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        // IF CLOSE TO PRINCESS OR PLAYER >> EXPLODE
        if (Exploded == false && enemy == null)
        {
            StartCoroutine(Explode(transform.position, 1f));
            Exploded = true;
        }
    }
}
