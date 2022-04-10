using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private int score1 = 20;
    private int score2=1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayFollowingScore();
    }

    void displayFollowingScore(){
        if(score1>score2){
            Player1.SetActive(true);
            Player2.SetActive(false);
        }
    }
}
