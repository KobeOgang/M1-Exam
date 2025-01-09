using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    public Star gameManager; 



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.collect);
            Debug.Log("Ball hit the star!");
            gameManager.UpdateScore(100); 
            Destroy(gameObject); 
        }
    }
}
