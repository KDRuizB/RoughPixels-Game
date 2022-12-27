using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    [SerializeField] private AudioClip spawnSoundClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyTimer());
        audioSource = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemyTimer()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(3, spawnPoints.Length);

        yield return new WaitForSeconds(1);
        Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        StartCoroutine(enemyTimer());
        audioSource.clip = spawnSoundClip; 
        audioSource.Play();

    }
}
