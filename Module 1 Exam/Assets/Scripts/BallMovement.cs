using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 15f; 
    private Vector3 direction = new Vector3(1f, 0f, 1f).normalized; 
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; 
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Mathf.Abs(collision.contacts[0].normal.x) > 0.9f)
            {
                direction.x = -direction.x;
                AudioManager.instance.PlaySFX(AudioManager.instance.bounce);
            }
            else if (Mathf.Abs(collision.contacts[0].normal.z) > 0.9f)
            {
                direction.z = -direction.z;
                AudioManager.instance.PlaySFX(AudioManager.instance.bounce);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            direction = collision.transform.forward;
            AudioManager.instance.PlaySFX(AudioManager.instance.bounce);
        }
    }

    public void RespawnBall()
    {
        transform.position = initialPosition; 
        direction = new Vector3(1f, 0f, 1f).normalized;
    }

}
