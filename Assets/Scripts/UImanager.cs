using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public Text dashText;
    public Text dropText;
    public Text waveText;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + GameMaster.score;
        healthText.text = "HEALTH: " + Player.PlayerStats.Health;

        if (PlayerMovement.timeUntilDash < 0.01f) dashText.text = "DASH!";
        else dashText.text = "DASH IN: " + (int)(PlayerMovement.timeUntilDash+1);

        if (PlayerMovement.timeUntilDrop < 0.01f) dropText.text = "DROP!";
        else dropText.text = "DROP IN: " + (int)(PlayerMovement.timeUntilDrop + 1);

        waveText.text = "WAVE: " + BookSpawner.waveCount;
    }
}
