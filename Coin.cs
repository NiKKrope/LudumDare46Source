using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float fly_speed;
    private Transform playerPOS;

    // Start is called before the first frame update
    void Start()
    {
        playerPOS = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPOS.position, fly_speed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound("coin");
        PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
        player.coins += 1;
        Destroy(gameObject);
    }
}
