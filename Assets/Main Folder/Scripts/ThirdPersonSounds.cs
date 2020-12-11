﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonSounds : MonoBehaviour
{

    Animator m_Animator;

    //public AK.Wwise.Switch MySwtich;

    private bool jump;
    public AK.Wwise.Event FootStepEvent;
    public AK.Wwise.Switch MyMateral;
    public AK.Wwise.Switch MyMovement;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FootStepPlay(){
        //MySwitch.SetValue(gameObject);
        //AkSoundEngine.PostEvent("footstep_player", gameObject);
        MyMovement.SetValue(gameObject);
        MyMateral.SetValue(gameObject);
        FootStepEvent.Post(gameObject);
    }

    public void JumpPlay(){
        AkSoundEngine.PostEvent("jump_player", gameObject);
    }
}
