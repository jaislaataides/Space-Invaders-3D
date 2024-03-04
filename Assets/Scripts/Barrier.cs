using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("You lost !!! Score" + GameManager.Instance.score);
            GameManager.Instance.Start();
        }
    }
}
