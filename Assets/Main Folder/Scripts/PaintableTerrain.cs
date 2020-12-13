using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D[] TerrainTextures;
    public TerrainData terraindata;
    public Terrain terrain;
	public Camera main;

    public Material material;
    



// Use this for initialization
//https://www.youtube.com/watch?v=IuBRITg7Cpw
void Start()
{
    //terrain = GetComponent<Terrain>();
	

}

void FixedUpdate() {
    Vector3 pos = main.transform.position;
    int x = Mathf.CeilToInt(pos.x);
    int z = Mathf.CeilToInt(pos.z);
	Debug.Log(terrain.terrainData.GetHeight(x,z));

    
    if(Input.GetKey(KeyCode.G)){
        
    }
    
}

 public void CreateTerrain(){
                 SplatPrototype[] tex = new SplatPrototype [TerrainTextures.Length];
                 for (int i=0; i<TerrainTextures.Length; i++) {
                         tex [i] = new SplatPrototype ();
                         tex [i].texture = TerrainTextures [i];    //Sets the texture
                         tex [i].tileSize = new Vector2 (1, 1);    //Sets the size of the texture
                 }
                 terraindata.splatPrototypes = tex;
                 terrain = Terrain.CreateTerrainGameObject (terraindata).GetComponent<Terrain> ();
     }

}
