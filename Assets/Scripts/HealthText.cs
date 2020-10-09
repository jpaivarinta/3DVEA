using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Player player;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.Health.ToString("0");
        if (player.Health < 50f && player.Health > 25f)
        {
            healthText.color = Color.yellow;
        }
        else if (player.Health < 25f)
        {
            healthText.color = Color.red;
        }
    }
}
