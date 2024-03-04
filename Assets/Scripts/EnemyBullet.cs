using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float life = 10;

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

    void OnTriggerEnter(Collider  other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            if(GameManager.Instance.barrierShotsLeft(other.gameObject.name) == 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
