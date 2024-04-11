using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    
    public Transform spawnPoint;
    
    public float timeBetweenWaves = 5f;
    private float countdown = 2f; // seconds until wave spawns
    
    public TextMeshProUGUI waveCountdownText;

    public GameManager gameManager;
    
    private int waveNum = 0;
    
    // Update is called once per frame
    void Update()
    {
        // don't start next wave until entire wave is gone
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        // check if level is finished
        if (waveNum == waves.Length)
        {
            gameManager.LevelComplete();
            this.enabled = false;
        }
        
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNum];

            // EnemiesAlive = wave.count; // to prevent next wave from starting in the middle of prev wave
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        
        waveNum++;
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
