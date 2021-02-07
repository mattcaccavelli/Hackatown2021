using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{

    Transform bar;
    Transform maxBar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.GetChild(0);
        maxBar = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3((FarmManager.player.stamina / FarmManager.player.maxStamina) * maxBar.localScale.x, 1, 1);
    }
}
