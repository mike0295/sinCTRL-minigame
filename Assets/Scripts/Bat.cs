using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [System.Serializable]
    public class BatStats
    {
        public int Health = 80;
        public int Damage = 30;
    }

    public BatStats batStats = new BatStats();

    public void DamageBat(int damage)
    {
        batStats.Health -= damage;
        if (batStats.Health <= 0)
        {
            GameMaster.KillBat(this);
        }
    }
}
