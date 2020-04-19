using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerGetHit, enemyGetHit, coin, game_over, shoot, treeGetHit, skeletonExplode, itemBought, cantBuyItem;
    static AudioSource AudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerGetHit = Resources.Load<AudioClip>("Player_Get_Hit");
        coin = Resources.Load<AudioClip>("Coin_pickup");
        game_over = Resources.Load<AudioClip>("Game_over");
        shoot = Resources.Load<AudioClip>("Shoot_sound");
        treeGetHit = Resources.Load<AudioClip>("Tree_get_Hit");
        skeletonExplode = Resources.Load<AudioClip>("Skeleton_explode");
        enemyGetHit = Resources.Load<AudioClip>("Bullet_Hit_ennemy");
        itemBought = Resources.Load<AudioClip>("Buy_Weapon");
        cantBuyItem = Resources.Load<AudioClip>("Cant_Buy_Weapon");
        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
        case "playerGetHit":
                AudioSrc.PlayOneShot(playerGetHit);
                break;
        case "coin":
                AudioSrc.PlayOneShot(coin);
                break;
        case "gameOver":
                AudioSrc.PlayOneShot(game_over);
                break;
        case "shoot":
                AudioSrc.PlayOneShot(shoot);
                break;
        case "treeGetHit":
                AudioSrc.PlayOneShot(treeGetHit);
                break;
        case "skeletonExplode":
                AudioSrc.PlayOneShot(skeletonExplode);
                break;
        case "enemyGetHit":
                AudioSrc.PlayOneShot(enemyGetHit);
                break;
        case "itemBought":
                AudioSrc.PlayOneShot(itemBought);
                break;
        case "cantBuyItem":
                AudioSrc.PlayOneShot(cantBuyItem);
                break;

        }

    }
}
