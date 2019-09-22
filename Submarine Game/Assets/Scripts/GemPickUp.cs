using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemPickUp : MonoBehaviour {
    private bool pickedUp;
    public int coinValue = 1;

    private SpawnGems zones;
    // Start is called before the first frame update
    void Awake() {
        pickedUp = false;

        zones = GameObject.Find("SpawnZones").GetComponent<SpawnGems>();
       
    }

    private void OnTriggerEnter2D(Collider2D info) {
        if(!pickedUp) {
            if(info.gameObject.CompareTag("Player")) {
                pickedUp = true;
                //display the score
                ScoreManager.instance.ChangeScore(coinValue);

                //destroy gem
                Destroy(gameObject);
               
                //spawn another gem              
                zones.Spawn();
            }
        }
    }
}
