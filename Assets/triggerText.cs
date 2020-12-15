using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerText : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject UI;
    void Start()
    {
        UI.SetActive(false);
    }


    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player"){ 
            UI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider player) {
        if(player.tag == "Player"){
            UI.SetActive(false);
        }
    }

    // Update is called once per frame
   
}
