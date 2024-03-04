using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float horizontalInput;

    void Update()
    {
        if(transform.position.x >= GameManager.Instance.getRightBound())
        {
            transform.Translate(Vector3.right * Time.deltaTime * -30 * 100);
        }
        else if(transform.position.x <= GameManager.Instance.getLeftBound())
        {
            transform.Translate(Vector3.right * Time.deltaTime * 30 * 100);
        }

        if(transform.position.x < GameManager.Instance.getRightBound() && 
            transform.position.x > GameManager.Instance.getLeftBound())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 100);
        }
    }
}
