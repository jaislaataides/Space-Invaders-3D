// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyGun : MonoBehaviour
// {
//     private static float bulletSpeed = 90;

//     public static void shoot(Transform bulletspawner, GameObject EbulletPrefab)
//     {
//         var bullet = Instantiate(EbulletPrefab, bulletspawner.position, bulletspawner.rotation);
//         bullet.GetComponent<Rigidbody>().velocity = bulletspawner.forward * bulletSpeed;
//     }
// }