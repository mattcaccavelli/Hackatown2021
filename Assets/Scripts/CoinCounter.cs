using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCounter : MonoBehaviour
{
    public Text coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "" + FarmManager.player.score;
    }
}
