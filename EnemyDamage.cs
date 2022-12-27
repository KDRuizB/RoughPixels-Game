using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float MaxHitpoints = 100;
    private float HitPoints;
    public static int playerScore = 0;
    public Text scoreText;
    public int scoreDisplay;

    bool gameHasEnden = false;
    
    [SerializeField] private AudioClip enemySoundClip;
    [SerializeField] private AudioClip enemyHitSoundClip;

    private AudioSource audioSource;

    public void Start()
    {
        scoreText.text = playerScore.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        scoreDisplay = playerScore;
        if (playerScore >= 50)
        {
            if(gameHasEnden == false)
            {
                gameHasEnden = true;
                Debug.Log("YouSurvived!");
                FindObjectOfType<GameManager>().EndGame();
                //change to Game won scene and wait 2 sec
                Invoke("youWonScene", 1f);
                playerScore = 0;
            }
        }
    }

    void youWonScene()
    {
        SceneManager.LoadScene("youWon");
    }

    public void TakeHit(float damage)
    {
        MaxHitpoints -= damage;

        if (MaxHitpoints <= 0)
        {
            playerScore++;
            audioSource.clip = enemySoundClip;
            audioSource.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            audioSource.clip = enemyHitSoundClip;
            audioSource.Play();
            TakeHit(40);
        }
    }
}
