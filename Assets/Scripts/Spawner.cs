using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemys;
    public float respawntime = 4f;
    public int enemySpawncount = 2;
    private bool lastEnemySpawn=false  ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner()); 
    }

    // Update is called once per frame
    void Update()
    {
     if(lastEnemySpawn && FindObjectOfType<EnemyScript>() == null)
        {

           StartCoroutine(GameController.Instance.LevelComplete());
            
        }   
    }
    void SpawnEnemy()
    {
        int randomValue=Random.Range(0, enemys.Length);
        int randomXPos = Random.Range(-4, 4);
        Instantiate(enemys[randomValue], new Vector3(randomXPos,transform.position.y,transform.position.z), Quaternion.identity);
    }
    IEnumerator EnemySpawner()
    {
        for(int i=0;i<enemySpawncount;i++)
        {
            yield return new WaitForSeconds(respawntime);
            SpawnEnemy();
        }
        lastEnemySpawn = true;
        
    }
}
