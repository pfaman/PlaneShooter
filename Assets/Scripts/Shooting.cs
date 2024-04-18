using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1, spawnPoint2;
    public float bulletSpawnTime=0.3f;
    public GameObject muzzleEffect;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        muzzleEffect.SetActive(false);
        StartCoroutine(Shoot()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
        Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
    }
    IEnumerator Shoot()
    {

        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play(); 
            muzzleEffect.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            muzzleEffect.SetActive(false);

        }
        


    }
}
