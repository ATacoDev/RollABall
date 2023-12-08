using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Next button pressed!");
    }
}