using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenManager : MonoBehaviour
{

    public Text player1Text;
    public Text player2Text;

    // Start is called before the first frame update
    void Start()
    {
        player1Text.text = "Player 1: " + PersistentManagerScript.Instance.player1Score.ToString();
        player2Text.text = "Player 2: " + PersistentManagerScript.Instance.player2Score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        player1Text.text = "Player 1: " + PersistentManagerScript.Instance.player1Score.ToString();
        player2Text.text = "Player 2: " + PersistentManagerScript.Instance.player2Score.ToString();
    }
}
