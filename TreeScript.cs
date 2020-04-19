using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour
{
    public HealthBar healthbar;
    public float health;
    public const float MAX_HEALTH = 1000;
    public GameObject GetHitEffect;
    public GameObject DeathEffect;
    public Text TreeAttackText;

    // Start is called before the first frame update
    void Start()
    {
        TreeAttackText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("treeGetHit");
        StartCoroutine(UnderAttack());
        GameObject Leaves = Instantiate(GetHitEffect, transform.position, Quaternion.identity);
        health -= damage;
        healthbar.SetSize(health / MAX_HEALTH);
        if (health <= 0)
        {
            Die();
        }
        Destroy(Leaves, 3f);
    }
    void Die()
    {
        SoundManagerScript.PlaySound("gameOver");
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("GAME OVER, THE TRE DED");
    }
    IEnumerator UnderAttack()
    {
        TreeAttackText.text = "THE TREE IS UNDER ATTACK";
        yield return new WaitForSeconds(0.5f);
        TreeAttackText.text = "";
        yield return new WaitForSeconds(0.5f);
        TreeAttackText.text = "THE TREE IS UNDER ATTACK";
        yield return new WaitForSeconds(0.5f);
        TreeAttackText.text = "";
        yield return new WaitForSeconds(0.5f);
        TreeAttackText.text = "THE TREE IS UNDER ATTACK";
        yield return new WaitForSeconds(0.5f);
        TreeAttackText.text = "";
    }
}
