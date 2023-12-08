using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text countText;
    public Text resultText;
    public Text timerText;
    
    public GameController gameController;
    
    // Start is called before the first frame update
    private void Awake()
    {
        // Set the text property of our Result Text UI to an empty string, making the game over message blank
        resultText.text = "";
        countText.text = $"Remaining: {gameController.maxCollectiblesCount}";
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    public void SetCountText(int count)
    {
        // Update the text field of our 'countText' variable
        countText.text = $"Remaining: {gameController.maxCollectiblesCount - count}";
    }

    public void SetTimerText(int count)
    {
        timerText.text = "Time: " + count;
    }
}
