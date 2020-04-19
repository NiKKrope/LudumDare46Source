using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Transform bar;
    public Transform player;
    Vector3 playerPOS;
    void Start()
    {
        bar = transform.Find("Bar");
    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
    void Update()
    {

        playerPOS = bar.position;
        playerPOS.z = 0;
        bar.position = playerPOS;
    }
}
