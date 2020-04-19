using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsAmout : MonoBehaviour
{
    public PlayerScript player;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = player.coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.coins.ToString();
    }
}
