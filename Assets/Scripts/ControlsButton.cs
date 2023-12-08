using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Controls button pressed!");
        SceneManager.LoadScene("Controls");
    }
}