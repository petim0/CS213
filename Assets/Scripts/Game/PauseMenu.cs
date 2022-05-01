using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    public GameObject pMenu;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                resumeGame();
            } else pauseGame();
        }
    }

    public void resumeGame(){
        pMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void pauseGame(){
        pMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
