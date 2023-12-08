using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        GamePlaying,
        GameWon,
        GameLost
    };
    private GameView gameView;
    private GameStates gameState;
    public int maxCollectiblesCount;
    [SerializeField]
    private Enemy enemy;
    
    [SerializeField]
    private Enemy enemy2;

    public GameObject happyFace;
    public GameObject tears;
    public GameObject normalSmile;
    public GameObject scaredLeftEye;
    public GameObject scaredRightEye;
    public GameObject regularLeftEye;
    public GameObject regularRightEye;

    private bool gameWon;
    private bool gameOver = false;
    public string previousScene = "Level 1";
    private void Start()
    {
        gameView = GetComponentInChildren<GameView>();
        gameState = GameStates.GamePlaying;
        previousScene = SceneManager.GetActiveScene().name;
        maxCollectiblesCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        happyFace.SetActive(true);
        normalSmile.SetActive(false);
        tears.SetActive(false);
        enemy.UnfreezePosition();
    }
    
    private void OnGameWon()
    {
        gameState = GameStates.GameWon;
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        } else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        else
        {
            SceneManager.LoadScene("WinScreen");
        }
        // Set the text value of our result text
        gameView.resultText.text = "You Win!";
        //Hide count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
        gameWon = true;
        gameOver = true;
        enemy.FreezePosition();
    }
    private void OnGameLost()
    {
        gameState = GameStates.GameLost;
        SceneManager.LoadScene("LoseScreen");
        // Set the text value of our result text
        gameView.resultText.text = "You Lose.";
        //Hide count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
        happyFace.SetActive(false);
        normalSmile.SetActive(false);
        tears.SetActive(true);
        gameWon = false;
        gameOver = true;
        enemy.FreezePosition();
    }

    public void StateUpdate(GameStates newState)
    {
        //Exit condition- if the game is not in play, we cannot advance to win or lose
        if (gameState != GameStates.GamePlaying)
        {
            return;
        }
        
        switch (newState)
        {
            case GameStates.GamePlaying:
                break;
            case GameStates.GameWon:
                gameState = GameStates.GameWon;
                OnGameWon();
                break;
            case GameStates.GameLost:
                gameState = GameStates.GameLost;
                OnGameLost();
                break;
        }
    }

    public void OnPickUpCollectible(int playerCollectibleCount)
    {
        gameView.SetCountText(playerCollectibleCount);
        // Check if our 'count' is equal to or exceeded our maxCollectibles count
        if (playerCollectibleCount >= maxCollectiblesCount) 
        {
            StateUpdate(GameStates.GameWon);
        }
    }

    public void UpdateGameTimer(int timerCount)
    {
        gameView.SetTimerText(timerCount);
    }

    public void checkIfLoseFromEnemy()
    {
        if (enemy.isTouching() || enemy2.isTouching())
        {
            Debug.Log("Game Over");
            OnGameLost();
        }
    }

    public void FixedUpdate()
    {
        if (!gameOver)
        {
            checkIfLoseFromEnemy();
            if (enemy.isClose() || enemy2.isClose())
            {
                happyFace.SetActive(false);
                tears.SetActive(true);
                scaredLeftEye.SetActive(true);
                scaredRightEye.SetActive(true);
            }
            else
            {
                happyFace.SetActive(true);
                tears.SetActive(false);
                scaredLeftEye.SetActive(false);
                scaredRightEye.SetActive(false);
            } 
        }
        else if (gameOver && gameWon)
        {
            happyFace.SetActive(true);
            tears.SetActive(false);
            scaredLeftEye.SetActive(false);
            scaredRightEye.SetActive(false);
            regularLeftEye.SetActive(true);
            regularRightEye.SetActive(true);
        }
        else if (gameOver && !gameWon)
        {
            happyFace.SetActive(false);
            tears.SetActive(true);
            scaredLeftEye.SetActive(true);
            scaredRightEye.SetActive(true);
            regularLeftEye.SetActive(false);
            regularRightEye.SetActive(false);
        }
    }
}
