using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [System.Serializable]
    public static class PlayerStats {
        public static int Health = 100;
        public static int Damage = 30;
    }

    //public PlayerStats playerStats = new PlayerStats();

    public void DamagePlayer (int damage) {
        PlayerStats.Health -= damage;
        if (PlayerStats.Health <= 0) {
            GameMaster.KillPlayer(this);
        }
    }





}
