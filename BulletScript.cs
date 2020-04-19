using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPrefab;
    private GameObject bullet;
    public float bulletForce;
    public float fire_speed;
    private float can_fire = 1f; 
    public float spread;
    public int damage;
    public string weapon = "AR";
    public PlayerScript player;
    private int sniper_price =90;
    private int ar_price = 40;
    public Text ar_price_text;
    public Text sniper_price_text;


    void Start()
    {
        transform.rotation = firepoint.rotation;
    }
    void Update()
    {
        transform.rotation = firepoint.rotation;
        if (Input.GetButton("Fire1") && Time.time > can_fire)
        {
            Shoot();
            can_fire = Time.time + fire_speed;
        }
        if (weapon == "AR")
        {
            fire_speed = 0.1f;
            spread = 10;
            damage = 25;
            bulletForce = 10;
        }
        else if (weapon == "SNIPER")
        {
            fire_speed = 0.8f;
            spread = 2;
            damage = 100;
            bulletForce = 100;
        } else if (weapon == "PISTOL")
        {
            fire_speed = 0.5f;
            spread = 20;
            damage = 35;
            bulletForce = 10;
        }
    }
    void Shoot()
    {
        Bullet shot;
        SoundManagerScript.PlaySound("shoot");
        bullet = Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        bullet.transform.Rotate(0, 0, Random.Range(-spread / 2, spread / 2));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * -bulletForce, ForceMode2D.Impulse);
        shot = bullet.GetComponent<Bullet>();
        shot.damage = damage;
    }
    public void SetWeaponPistol(string weaponName)
    {
        if (0 <= player.coins)
        {
            SoundManagerScript.PlaySound("itemBought");
            player.coins -= 0;
            weapon = weaponName;
        }
        else { SoundManagerScript.PlaySound("cantBuyItem"); }
    }
    public void SetWeaponSniper(string weaponName)
    {
        if (sniper_price <= player.coins)
        {
            SoundManagerScript.PlaySound("itemBought");
            player.coins -= sniper_price;
            weapon = weaponName;
            sniper_price = 0;
            sniper_price_text.text = "UNLOCKED";
        }
        else { SoundManagerScript.PlaySound("cantBuyItem"); }
    }
    public void SetWeaponAR(string weaponName)
    {
        if (ar_price <= player.coins)
        {
            SoundManagerScript.PlaySound("itemBought");
            player.coins -= ar_price;
            weapon = weaponName;
            ar_price = 0;
            ar_price_text.text = "UNLOCKED";
        }
        else { SoundManagerScript.PlaySound("cantBuyItem"); }
    }

}
