using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    public Terrain terrain;
	public Camera main;


// Use this for initialization
//https://www.youtube.com/watch?v=IuBRITg7Cpw
void Start()
{
    //terrain = GetComponent<Terrain>();
	

}

private void Update() {
	Debug.Log(terrain.terrainData.GetHeight((int)main.transform.position.x, (int)main.transform.position.z));
}

}
