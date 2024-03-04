using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletspawner;
    public GameObject bulletPrefab;
    public float bulletSpeed = 90;
    public AudioSource src;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletspawner.position, bulletspawner.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletspawner.forward * bulletSpeed;
            GameManager.Instance.EnemyShoot();
            src.Play();
        }
    }
}