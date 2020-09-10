using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject mainMenuUI;

    public void Start()
    {
        Player.PlayerStats.Health = 100;
        GameMaster.score = 0;
        BookSpawner.waveCount = 0;
        mainMenuUI.SetActive(true);
        tutorialUI.SetActive(false);
    }

    public void PlayGame () {
        SceneManager.LoadScene("Main"); 
    }

    public void Tutorial () {
        mainMenuUI.SetActive(false);
        tutorialUI.SetActive(true);
    }

    public void GameExit ()
    {
        Application.Quit();
    }
}
