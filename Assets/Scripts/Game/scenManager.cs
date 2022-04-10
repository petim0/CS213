using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenManager : MonoBehaviour
{

    public string sceneToLoad;
    public Text player1Text;
    public Text player2Text;
    public Text time;
    private float ftime = 0;


    // Start is called before the first frame update
    void Start()
    {
        player1Text.text = "Player 1: " + PersistentManagerScript.Instance.player1Score.ToString();
        player2Text.text = "Player 2: " + PersistentManagerScript.Instance.player2Score.ToString();
        time.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        player1Text.text = "Player 1: " + PersistentManagerScript.Instance.player1Score.ToString();
        player2Text.text = "Player 2: " + PersistentManagerScript.Instance.player2Score.ToString();

        ftime += Time.deltaTime;
        float minutes = Mathf.FloorToInt(ftime / 60);
        float seconds = Mathf.FloorToInt(ftime % 60);
        time.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);


        //j'ai mis la gestion du gameover ici pour l'instant
        if(seconds == 120){
            LoadGameOver();
        }
    }

    void LoadGameOver(){
        SceneManager.LoadScene("GameOverScene");
    }
}
