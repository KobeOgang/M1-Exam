using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Star : MonoBehaviour
{
    public GameObject starPrefab; 
    public Transform ball; 
    public TMP_Text scoreText; 

    private int score = 0;
    private Vector3 spawnMin = new Vector3(-11.41f, 0f, 5.26f);
    private Vector3 spawnMax = new Vector3(17.33f, 0f, 13.43f);

    void Start()
    {
        SpawnStar();
        UpdateScoreUI();
    }

    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreUI();
        SpawnStar(); 
    }

    void SpawnStar()
    {
        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float randomZ = Random.Range(spawnMin.z, spawnMax.z);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, randomZ); 

        Instantiate(starPrefab, spawnPosition, Quaternion.identity)
            .GetComponent<StarTrigger>().gameManager = this; 
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
