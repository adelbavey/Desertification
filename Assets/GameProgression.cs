using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    // Start is called before the first frame update

    //List of bools;
    bool reachedOasis = false;
    bool takenOrb = false;

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
        Debug.Log(other.tag);
    }

}
