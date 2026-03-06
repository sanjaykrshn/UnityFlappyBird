using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private int score;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public Text highScore;
    public PersistanceManager persistanceManager;

    public bool isFirstTry = true;
    public bool pressedPlayed = false;

    private void Awake()
    {
        Pause();
        if(isFirstTry){
            gameOver.SetActive(false);
            getReady.SetActive(true);
        }
        SetHighestScore(persistanceManager.LoadScore());
    }

    public void Play()
    {
        pressedPlayed = true;
        
        // set score to 0
        SetScore(0);

        playButton.SetActive(false);
        gameOver.SetActive(false);

        if (getReady.activeSelf){
            getReady.SetActive(false);
        }

        Time.timeScale = 1f;
        player.enabled = true;

        // destroy all pipes
        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        for(int i = 0; i < pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }

        // reset the player position direction etc.
        player.ResetPlayer();

        // set firstTry to false
        isFirstTry = false;


    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();

        // get persistance score
        int persistanceScore = persistanceManager.LoadScore();
        // get current score
        int currentScore = GetScore();
        // var new score as max(persistance, current)
        int newScore = Mathf.Max(persistanceScore, currentScore);
        // take new score and update it to the persistance
        persistanceManager.SaveScore(newScore);
        SetHighestScore(persistanceManager.LoadScore());
    }


    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log("Add score by 1");
    }

    // Getter
    public int GetScore(){
        return score;
    }

    // Setter
    public void SetScore(int val){
        score = val;
        scoreText.text = score.ToString();
    }

    // Setter 
    public void SetHighestScore(int val){
        highScore.text = "High Score: " + val.ToString();
    }
}
