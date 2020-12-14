using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonSounds : MonoBehaviour
{

    Animator m_Animator;


    private bool jump;
    public AK.Wwise.Event FootStepEvent;


    void Start()
    {
        m_Animator = GetComponent<Animator>();

        // HELLO HELLO, these three lines should be in another script, the one that runs to main menu, so that we get windy sounds from the start
        float wind_value = 60;
        AkSoundEngine.SetState("GameState", "InForest");
        AkSoundEngine.PostEvent("Play_background", gameObject);
    }


    public void FootStepPlay(){
        //MyMovement.SetValue(gameObject); fix movement with if loop

        PlayerManagerN.my_obj.GetMaterial().SetValue(gameObject);
        FootStepEvent.Post(gameObject);
    }

    public void JumpPlay(){
        AkSoundEngine.PostEvent("jump_player", gameObject);
    }

    public void JumpLandingPlay()
    { 
        AkSoundEngine.PostEvent("landing_player", gameObject);
    }
}
