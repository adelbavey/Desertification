using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicState : MonoBehaviour
{
    
    float wind_value = 0;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            wind_value = 10;
            AkSoundEngine.SetRTPCValue("windiness", wind_value);

            uint des_men_state = 1129748651;
            uint curr_state = 1129748651;
            AKRESULT state_res = AkSoundEngine.GetState(4091656514,  out curr_state);  //the id for "GameState"
            Debug.Log(curr_state);
            Debug.Log(des_men_state);
            Debug.Log(state_res);

            if  (des_men_state == curr_state) 
            {
                AkSoundEngine.SetState("GameState", "InDesert");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wind_value = 60;
            AkSoundEngine.SetRTPCValue("windiness", wind_value);
        }
    }

}
