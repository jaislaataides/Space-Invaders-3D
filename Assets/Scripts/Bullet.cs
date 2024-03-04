using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float life = 2000;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            if(GameManager.Instance.barrierShotsLeft(other.gameObject.name) == 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("enemylv1"))
        {
            GameManager.Instance.IncreaseScore(10);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("enemylv2"))
        {
            GameManager.Instance.IncreaseScore(20);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("enemylv3"))
        {
            GameManager.Instance.IncreaseScore(30);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
