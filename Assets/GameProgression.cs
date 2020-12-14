using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    // Start is called before the first frame update

    //List of bools;
    bool reachedOasis = false;
    bool takenOrb = false;

    public GameObject Desert;
    public GameObject Forest;

    void Start()
    {
        Debug.Log("Starting GameProgression");
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    void OnCollisionEnter(Collision other) {
        //Check game collisions
        Debug.Log(other.collider.tag);
        Debug.Log("coll");
        
    }

    void OnTriggerEnter(Collider other) {
        
        
        //Picking up item at camp
        if(other.tag == "SpecialItem"){
            Debug.Log("asda");
            other.gameObject.active = false;
            //AkSoundEngine.PostEvent("pick_up_item_player", gameObject);
            takenOrb = true;
        }

        //Going back to the oasis with orb
        if(other.gameObject.name == "BridgeTrigger" && takenOrb){
            Debug.Log("yaaay");
            levelup();

        }

    }


    void levelup(){
        //Throw the object in water

        //Trigger cutscene with growing forest

        //Change to forest environment.
        Desert.SetActive(false);
        Forest.SetActive(true);

    }

}
