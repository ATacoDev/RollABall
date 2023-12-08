using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spotlights : MonoBehaviour
    {
        public Light spotlight;
        public void FlickerLight()
        {
            // flicker the light every few seconds
            GetComponent<Light>().intensity = Random.Range(1.0f, 10.0f);
        }

        public void Update()
        {
            FlickerLight();
        }
    }
