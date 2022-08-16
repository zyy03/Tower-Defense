using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public Text waveCountdownText;

    public float timeBetweenWave = 5f;
    private float countdown = 3f;

    private int waveNumber = 1;

    void Update(){
        if(countdown <= 0f){
            StartCoroutine(spawnWave());
            countdown = timeBetweenWave;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawnWave(){
        Debug.Log("Wave Incoming!!");
        for( int i = 0; i < waveNumber; i++){
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    void spawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
