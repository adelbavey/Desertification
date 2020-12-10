using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonSounds : MonoBehaviour
{

    Animator m_Animator;

    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FootStepPlay(){
        AkSoundEngine.PostEvent("footstep_player", gameObject);
    }

    public void JumpPlay(){
        AkSoundEngine.PostEvent("jump_player", gameObject);
    }
}
