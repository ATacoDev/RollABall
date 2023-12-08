using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsNavigator : MonoBehaviour
{
    public void onSpacePressed()
    {
        Debug.Log("Back button pressed!");
        SceneManager.LoadScene("Menu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpacePressed();
        }
    }
}
