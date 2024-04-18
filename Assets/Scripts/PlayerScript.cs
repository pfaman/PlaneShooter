using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject damageEffect;
    public float hSpeed = 10f;
    public float padding = 0.2f;
    float minX,minY;
    float maxX,maxY;
    public GameObject explosion;
    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;
    public PlayerHealthBar playerHealthBar;
    public CoinCount coinCount;
    public GameController gameController;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    [SerializeField]
    int Health;

    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
        damage = barFillAmount / health;
    }
    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.SetAmount(barFillAmount);
        }
    }
    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        /*
                //Player controller for PC
                float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * hSpeed;
                float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * hSpeed;
                float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
                transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);

                //

                float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
                transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);*/
        if (Input.GetMouseButton(0))
        {
            Vector3 newPos= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z));
            //transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);
            Vector3 curPos = new Vector3(transform.position.x,transform.position.y);
            transform.position = Vector3.Lerp(curPos, newPos, 10 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageEff = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageEff);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                gameController.GameOver();
                Destroy(gameObject);
                
                
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 0.2f);
            }
            
        }
        if (collision.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
            Destroy(collision.gameObject);
            coinCount.AddCount();
        }
        
    }
}
