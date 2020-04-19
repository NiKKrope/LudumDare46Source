using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    public GameObject ZOMBIE;
    public GameObject SKELETON;
    public float spawn_interval = 1;
    public float spawn_rate;
    public AudioSource SoundThing;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(SoundThing);
        InvokeRepeating("decreace_delay", 0f, 1f);
        StartCoroutine(SPAWN_ENEMY());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InvokeRepeating("SPAWN_ENEMY", 0f, spawn_interval);
    }
    public IEnumerator SPAWN_ENEMY()
    {
        
        Debug.Log(spawn_interval);
        yield return new WaitForSeconds(spawn_interval);
        Transform SPAWN = GameObject.Find("EnemySpawn2").transform;
        int spawn_location = Random.Range(1, 9);
        int type_of_enemy = Random.Range(1, 3);
        if (spawn_location == 1) { SPAWN = GameObject.Find("EnemySpawn1").transform; }
        else if (spawn_location == 2) { SPAWN = GameObject.Find("EnemySpawn2").transform; }
        else if (spawn_location == 3) { SPAWN = GameObject.Find("EnemySpawn3").transform; }
        else if (spawn_location == 4) { SPAWN = GameObject.Find("EnemySpawn4").transform; }
        else if (spawn_location == 5) { SPAWN = GameObject.Find("EnemySpawn5").transform; }
        else if (spawn_location == 6) { SPAWN = GameObject.Find("EnemySpawn6").transform; }
        else if (spawn_location == 7) { SPAWN = GameObject.Find("EnemySpawn7").transform; }
        else if (spawn_location == 8) { SPAWN = GameObject.Find("EnemySpawn8").transform; }
        if (type_of_enemy == 1) { Instantiate(ZOMBIE, SPAWN.position, SPAWN.rotation); }
        else if (type_of_enemy == 2) { Instantiate(SKELETON, SPAWN.position, SPAWN.rotation); }
        StartCoroutine(SPAWN_ENEMY());
    }
    void decreace_delay()
    {
        if (spawn_interval > 1.01)
        {
            spawn_interval -= spawn_rate;
        } else if (spawn_interval < 1) { spawn_interval = 1f; }
    }
}
