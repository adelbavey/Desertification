using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWindAmount : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float wind_value = 85;
            AkSoundEngine.SetRTPCValue("windiness", wind_value);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float wind_value = 60;
            AkSoundEngine.SetRTPCValue("windiness", wind_value);
        }
    }
}
