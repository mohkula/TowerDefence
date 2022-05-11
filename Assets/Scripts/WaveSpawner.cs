
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
   
public static int EnemiesAlive = 0;

public Wave[] waves;

public Transform spawnPoint;

public float timeBetweenWaves = 5f;

private float countdown = 2f;

private bool levelWon;

public Text waveCountdownText;

public int waveIndex = 0;

public GameManager gameManager;


void Start()
{
    levelWon = false;
    EnemiesAlive = 0;
    waveIndex = 0;
}
void Update (){



if(EnemiesAlive > 0)
{
    return;
}

if(levelWon && EnemiesAlive <= 0)
{
    gameManager.WinLevel();
}

if(countdown <= 0f)
{

StartCoroutine(SpawnWave());
countdown = timeBetweenWaves;
return;

}

countdown -= Time.deltaTime;

countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

waveCountdownText.text = string.Format("{0:00.00}", countdown);

}

IEnumerator SpawnWave(){


PlayerStats.Rounds ++;
   
Wave wave = waves[waveIndex];

   for (int i = 0; i < wave.enemies.Length; i++)
    {
       
     
       
         
               for (int j = 0; j < wave.enemies[i].count; j++)
               {
                SpawnEnemy(wave.enemies[i].enemy);
             
                yield return new WaitForSeconds(wave.enemies[0].rate);   
               } 
                
          yield return new WaitForSeconds(1f / timeBetweenWaves);   

        
      
          
       
       
    }
    waveIndex++;

    if(waveIndex >= waves.Length)
    {
        levelWon = true;
    }
    

    
}


void SpawnEnemy(GameObject enemy){


    Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    EnemiesAlive ++;
}

}
