using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour {

    private GameObject[] children;
    private SpawnZone sp;
    public GameObject gemPrefab;

    private const float gemRadius = 0.5f;
    void Awake() {
        if(children == null) {
            children = GameObject.FindGameObjectsWithTag("Spawn Zone");
        }
    }
    public void Spawn() {
        bool collided = true;
        Vector3 pos = Vector3.zero;
        while(collided) {
            collided = false;
            //get a random spawn zone
            int i = Random.Range(0, children.Length);
            sp = children[i].GetComponent<SpawnZone>();
            
            //get a random position inside spawn zone
            float rnd_X = Random.Range(-sp.size.x / 2, sp.size.x / 2);
            float rnd_Y = Random.Range(-sp.size.y / 2, sp.size.y / 2);

            pos = new Vector3(rnd_X, rnd_Y, 0f) + sp.center;
            
            //check if the random position collides with an object
            if(Physics2D.OverlapCircle(pos, gemRadius)){
                Debug.Log("Collided");
                collided = true;
            }
        }

        Instantiate(gemPrefab, pos, Quaternion.identity);
    }
    
}
