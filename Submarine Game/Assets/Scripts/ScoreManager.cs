using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    //only one istance of ScoreManager needs to be instantiated hence static
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    private int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
    
    public void ChangeScore(int coinValue) {
        score += coinValue;
        text.text = "x " + score.ToString();
    }

    //called from EnemyAI when player is killed
    public void EndOfGame() {
        Debug.Log("Game Over " + score.ToString());
        if(score > 20) {
            Debug.Log("Good job!");
        }
        else if(score > 50) {
            Debug.Log("Outstanding!");
        }
        else {
            Debug.Log("Git gud!");
        }
    }
}
