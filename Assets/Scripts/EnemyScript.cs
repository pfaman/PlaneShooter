using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform []GunPoint1;
    
    public GameObject enemyBullet;
    public float enemyBulletSpawnTime=0.5f;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefabs;
    public float speed = 1f;
    public float health = 10f;
    public GameObject damageEffect;
    float barSize = 1.02f;
    float damage = 0;
    public HealthBar healthBar;
    public GameObject coinPrefabs;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
        damage = barSize / health;
        healthBar.SetSize(barSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);
        }
    }
    void EnemyFire()
    {
        for(int i = 0; i < GunPoint1.Length; i++)
        {
            Instantiate(enemyBullet, GunPoint1[i].position, Quaternion.identity);
        }
       // Instantiate(enemyBullet, GunPoint1.position, Quaternion.identity);
       // Instantiate(enemyBullet, GunPoint2.position, Quaternion.identity);
    }
    IEnumerator EnemyShooting()
    {
        //
        while (true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
            
            Destroy(collision.gameObject);
            GameObject damageEff=Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageEff,0.05f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
                Instantiate(coinPrefabs, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameObject enemyExplosion = Instantiate(enemyExplosionPrefabs, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.4f);
            }
            
        }
       
    }
}
