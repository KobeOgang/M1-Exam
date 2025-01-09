using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LivesManager : MonoBehaviour
{
    public int lives = 3;
    public BallMovement ball; 
    public TMP_Text livesText; 
    public GameObject gameOverText; 

    void Start()
    {
        UpdateLivesUI();
        gameOverText.SetActive(false); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            lives--;
            UpdateLivesUI();

            if (lives > 0)
            {
                ball.RespawnBall(); 
            }
            else
            {
                gameOverText.SetActive(true); 
                Debug.Log("Game Over");
            }
        }
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }
   
}
