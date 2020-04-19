using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float move_speed;
    Vector2 movement;
    public HealthBar healthbar;
    public float health = 200f;
    public const int MAX_HEALTH = 200;
    public GameObject DeathEffect;
    public GameObject GetHitEffect;
    public Animator anim;
    public int coins;
    public Canvas shopPanel;
    private bool shopOpened = false;

    void Start()
    {
        
    }
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));
        if (Input.GetButtonDown("F") && shopOpened == false)
        {
            shopPanel.enabled = true;
            Time.timeScale = 0;
            shopOpened = true;
        }
        else if (Input.GetButtonDown("F") && shopOpened == true)
        {
            shopPanel.enabled = false;
            Time.timeScale = 1;
            shopOpened = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("playerGetHit");
        GameObject GreenBlood = Instantiate(GetHitEffect, transform.position, Quaternion.identity);
        health -= damage;
        healthbar.SetSize(health / MAX_HEALTH);
        if (health <= 0)
        {
            Die();
        }
        Destroy(GreenBlood,3f);
    }
    void Die()
    {
        SoundManagerScript.PlaySound("gameOver");
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void CloseShop()
    {
        shopPanel.enabled = false;
        Time.timeScale = 1;
        shopOpened = false;
    }
}
