using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public TMP_Text hpText; 

    private int score = 0;
    private int hp = 3;
    public AudioClip gameOversound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateHPText(); 
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateHPText()
    {
        hpText.text = "HP: " + hp.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void LeaveScoreAlone()
    {
        
        UpdateScoreText();
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        UpdateScoreText();
    }

    

    public void IncreaseScoreForCombo(int comboCount)
    {
        int comboPoints = comboCount * 10;
        IncreaseScore(comboPoints);
    }

    public void DecreaseHP()
    {
        
        
        hp--;
        UpdateHPText();
        
        if (hp == 0)
        {
            
            Debug.Log("Game Over");
            GameOver();
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        AudioSystem.Play(gameOversound);
        Invoke("RestartScene", gameOversound.length);
    }
}
