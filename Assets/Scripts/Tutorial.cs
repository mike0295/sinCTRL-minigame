using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject tutorialUI;

    public void MainMenu() {
        mainMenuUI.SetActive(true);
        tutorialUI.SetActive(false);
    }
}
