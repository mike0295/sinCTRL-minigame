using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class BookWave {
        public Transform book;
        public int count;
        public float rate;

    }

    public static int waveCount = 0;

    public BookWave[] bookWaves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;

    private SpawnState state = SpawnState.COUNTING;

    private float searchCountdown = 1f;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING) { 
            if(!EnemyIsAlive()) {
                WaveCompleted();
            } else {
                return;
            }
        }

        if(waveCountDown <= 0) { 
            if(state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(bookWaves[nextWave]));
            }
        } else {
            waveCountDown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    void WaveCompleted () {
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if(nextWave+1 > bookWaves.Length-1) {
            nextWave = 0;
            Debug.Log("loop");
        } else {
            nextWave++;

        }

    }

    IEnumerator SpawnWave(BookWave _wave) {
        state = SpawnState.SPAWNING;
        waveCount++;
        if (Player.PlayerStats.Health <= 80) Player.PlayerStats.Health += 20;
        else Player.PlayerStats.Health = 100;

        for (int i=0; i<_wave.count; i++) {
            SpawnBook(_wave.book);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnBook (Transform _book) {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_book, _sp.position, _sp.rotation);
    }
}
