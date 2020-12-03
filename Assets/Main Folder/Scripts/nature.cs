using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnable : MonoBehaviour {
        public int Amount;
        public  GameObject SpawnableObject;

        public spawnable(int amount, GameObject spawnableObject){
            Amount = amount;
            SpawnableObject = spawnableObject;
        }




}


public class nature : MonoBehaviour
{



    public GameObject plane;
    public GameObject tree1;
    public GameObject tree2;
    public int numberOfTrees;
    public int numberOfRocks;

    public GameObject grass;
    public int numberOfGras;

    public List<GameObject> rocks;
    public List<GameObject> trees;
    //public List<spawnable> spawns;

    // Start is called before the first frame update
    void Start()
    {


        //Get size of plane
        Vector3 max = plane.transform.localScale;
        Vector3 test = plane.transform.localPosition;
        //Debug.Log(plane.GetComponent<ths>._maxXPos);
        
        

        //GameObject temp = Instantiate(tree, transform.position, transform.rotation);
        float _maxXPos = transform.position.x + transform.localScale.x / 2;
        float _maxZPos = transform.position.z + transform.localScale.z / 2;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-_maxXPos * 10, _maxXPos * 10), 0, Random.Range(-_maxZPos * 10, _maxZPos * 10));
            Quaternion q = Quaternion.Euler(0, Random.rotation.y, 0);
            GameObject treeSpawn = Instantiate((Random.Range(-1f, 1f) > 0 ? tree1 : tree2), pos, q);
            treeSpawn.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.3f, 0.3f), Random.Range(-0.1f, 0.1f));
            treeSpawn.transform.Rotate(0,Random.Range(0, 1000),0,Space.Self);

            //Debug.LogError("Spwaning tree:" + i);
        }

        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-_maxXPos * 10, _maxXPos * 10), 0, Random.Range(-_maxZPos * 10, _maxZPos * 10));
            Quaternion q = Quaternion.Euler(0, Random.rotation.y, 0);
            GameObject rockSpawn = Instantiate(rocks[Random.Range(0, rocks.Count)], pos, q);
            rockSpawn.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.3f, 0.3f), Random.Range(-0.1f, 0.1f));
            rockSpawn.transform.Rotate(0,Random.Range(0, 1000),0,Space.Self);
            
        }


        for (int i = 0; i < numberOfGras; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-_maxXPos * 10, _maxXPos * 10), 0, Random.Range(-_maxZPos * 10, _maxZPos * 10));
            Quaternion q = Quaternion.Euler(0, Random.rotation.y, 0);
            GameObject grassSpawn = Instantiate(grass, pos, q);
            grassSpawn.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.3f, 0.3f), Random.Range(-0.1f, 0.1f));
            grassSpawn.transform.Rotate(0,Random.Range(0, 1000),0,Space.Self);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
