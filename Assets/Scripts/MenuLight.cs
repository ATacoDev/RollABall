using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuLight : MonoBehaviour
{
    public Light spotlight;
    public void FlickerLight()
    {
        // flicker the light every few seconds
        GetComponent<Light>().intensity = Random.Range(1.0f, 3.0f);
    }

    public void Update()
    {
        FlickerLight();
    }
}