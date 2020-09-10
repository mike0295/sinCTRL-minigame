using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;

    private void Start()
    {
        score.text = "YOUR SCORE: " + GameMaster.score;
    }

    public void MainMenu() {
        Debug.Log("click!");
        SceneManager.LoadScene("Main Menu");
    }

    public void Regame() {
        Player.PlayerStats.Health = 100;
        GameMaster.score = 0;
        BookSpawner.waveCount = 0;
        SceneManager.LoadScene("Main");
    }

}
