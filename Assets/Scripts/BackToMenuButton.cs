using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Back button pressed!");
        SceneManager.LoadScene("Menu");
    }
}