using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [System.Serializable]
    public class BookStats
    {
        public int Health = 80;
        public int Damage = 30;
    }

    public BookStats bookStats = new BookStats();

    public void DamageBook(int damage)
    {
        bookStats.Health -= damage;
        if (bookStats.Health <= 0)
        {
            GameMaster.KillBook(this);
        }
    }
}
