using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameProgression : MonoBehaviour
{
    // Start is called before the first frame update

    //List of bools;
    bool reachedOasis = false;
    bool takenOrb = false;

    public GameObject Desert;
    public GameObject Forest;

    public GameObject VideoCanvas;

    public VideoPlayer vid;
    
    void Start()
    {
        Debug.Log("Starting GameProgression");
    }

    // Update is called once per frame



    void OnCollisionEnter(Collision other) {
        //Check game collisions
        Debug.Log(other.collider.tag);
        Debug.Log("coll");
        
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Oasis" && !reachedOasis){
            AkSoundEngine.SetState("GameState", "InDesert");
            AkSoundEngine.PostEvent("Play_background", gameObject);
            reachedOasis = true;
        }


        //Picking up item at camp
        if(other.tag == "SpecialItem"){
            Debug.Log("asda");
            other.gameObject.SetActive(false);
            //AkSoundEngine.PostEvent("pick_up_item_player", gameObject);
            takenOrb = true;
        }

        //Going back to the oasis with orb
        if(other.gameObject.name == "BridgeTrigger" && takenOrb){
            Debug.Log("yaaay");
            StartCoroutine(levelup());

        }

    }

    public IEnumerator levelup()
        {
            AkSoundEngine.PostEvent("Play_splash", gameObject);
            Desert.SetActive(false);
            Destroy(Desert);
            Forest.SetActive(true);
            //yield return new WaitForSeconds(2);
            //Play video
            
            //VideoCanvas.SetActive(true);
            //vid.Play();
            //float time = (float) vid.length;
            yield return new WaitForSeconds(2);
            //VideoCanvas.SetActive(false);
            AkSoundEngine.SetState("GameState", "InForest");
            AkSoundEngine.PostEvent("Play_background", gameObject);
        }

    /*void levelup(){
        //Throw the object in water

        //Trigger cutscene with growing forest

        //Change to forest environment.
        Desert.SetActive(false);
        Forest.SetActive(true);
        

    }*/

}
