using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonSounds : MonoBehaviour
{

    Animator m_Animator;

    //public AK.Wwise.Switch MySwtich;

    private bool jump;
    public AK.Wwise.Event FootStepEvent;
    public AK.Wwise.Event JumpLandingEvent;


    // Start is called before the first frame update

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        AkSoundEngine.SetState("GameState", "InGame");
        AkSoundEngine.PostEvent("Play_background", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FootStepPlay(){
        //MySwitch.SetValue(gameObject);
        //AkSoundEngine.PostEvent("footstep_player", gameObject);
        //MyMovement.SetValue(gameObject);

        PlayerManagerN.my_obj.GetMaterial().SetValue(gameObject);
        FootStepEvent.Post(gameObject);
    }

    public void JumpPlay(){
        AkSoundEngine.PostEvent("jump_player", gameObject);
    }

    public void JumpLandingPlay()
    {
        //MySwitch.SetValue(gameObject);
        //AkSoundEngine.PostEvent("footstep_player", gameObject);
        //MyMovement.SetValue(gameObject);

        //PlayerManagerN.my_obj.GetMaterial().SetValue(gameObject);
        JumpLandingEvent.Post(gameObject);
    }
}
