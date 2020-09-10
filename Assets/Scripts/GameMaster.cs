using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static int score = 0;

    public static void KillPlayer(Player player) {
        Destroy(player.gameObject);
        SceneManager.LoadScene("GameOver");
    }

    public static void KillBat(Bat bat) {
        Destroy(bat.gameObject);
        score++;
    }

    public static void KillBook(Book book)
    {
        Destroy(book.gameObject);
        score += 2;
    }

}
