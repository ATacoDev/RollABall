using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ButtonCommand : MonoBehaviour
{
    public GameObject cursor;
    public abstract void OnSpacePressed();
}