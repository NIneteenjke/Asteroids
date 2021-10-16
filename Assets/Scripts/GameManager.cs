using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;

    public GameObject gameOverPanel;
    public int score {get; private set;}
    public Text scoreText;

    public Text finalScoreText;
    public int lives {get; private set;}
    public Text livesText;
    public float respawnTime = 3.0f;

    public float respawnInvulTime = 3.0f;
    
    
    public void PlayerDied()
    {
        SetLives(this.lives - 1);

        if (lives <= 0)
        {
            GameOver();
        } 
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }

       

    }
    
    // void Update()
    // {
    //     if(PlayerPrefs.HasKey("score"))
    //         {
    //         PlayerPrefs.SetInt("score",score);
    //         PlayerPrefs.Save();
    //         }
    // }
    
    private void Start()
    {
        SetScore(0);
        SetLives(1);
        Respawn();
    }

    
    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collision");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), this.respawnInvulTime);
    }
    
    public void AsteroidDestoyed(Asteroid asteroid)
    {
        if (asteroid.size < 0.75f)
        {
            SetScore(this.score += 15);
        }
        else if(asteroid.size < 1.25f)
        {
            SetScore(this.score += 10);
        } else 
        {
            SetScore(this.score += 5);
        }
    }

    public void UFODestoyed(UFO ufo)
    {
        if (ufo.size < 1.25f)
        {
            SetScore(this.score += 30);
        }
        
    }
    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);   
        this.finalScoreText.text = score.ToString();
    }
    
    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        this.livesText.text = lives.ToString();
    }
}
