using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PreGame : MonoBehaviour
{
    public ToggleGroup toggleGroup1;
    public ToggleGroup toggleGroup2;

    public Slider gameTimer;

    public Slider R1;
    public Slider G1;
    public Slider B1;

    public Slider R2;
    public Slider G2;
    public Slider B2;


    //public Button playButton;



    public Toggle currentSelection1{
        get { return toggleGroup1.ActiveToggles().FirstOrDefault(); }
    }

    public Toggle currentSelection2{
        get { return toggleGroup2.ActiveToggles().FirstOrDefault(); }
    }

    // Start is called before the first frame update
    void Start()
    {
//        toggleGroup1 = GetComponent<ToggleGroup>();
//        toggleGroup2 = GetComponent<ToggleGroup>();


 //       Debug.Log("First selected" + currentSelection1.name);
  //      Debug.Log("Second selected" + currentSelection2.name);
    }

    public int player1Controls(){
        string s = currentSelection1.name;
        if (s.Equals("Player 1 ARROW Toggle")){
            return 0;
        } else if (s.Equals("Player 1 MOUSE Toggle")) {
            return 2;
        } else if (s.Equals("Player 1 WASD Toggle")){
            return 1;
         
        } else {
  //          Debug.Log("NAME: "+ s);
  //          Debug.Log("NUUUUUUUUUUULLLLL");
            return -1;
        }
    }

    public int player2Controls(){
        string s = currentSelection2.name;
        if (s.Equals("Player 2 ARROW Toggle")){
            return 0;
        } else if (s.Equals("Player 2 MOUSE Toggle")) {
            return 2;
        } else if (s.Equals("Player 2 WASD Toggle")){
            return 1;
         
        } else {
   //         Debug.Log("NAME: "+ s);
   //         Debug.Log("NUUUUUUUUUUULLLLL");
            return -1;
        }
    }

    public InputKeyboard player2ControlsKey(){
        if (currentSelection2.name.Equals("WASD")){
            return InputKeyboard.wasd;
        } else if (currentSelection2.name.Equals("MOUSE")) {
            return InputKeyboard.mouse;
        } else if (currentSelection2.name.Equals("ARROW")){
            return InputKeyboard.arrows;
        } else {
    //         Debug.Log("NUUUUUUUUUUULLLLL");
            return InputKeyboard.arrows;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var toggles1 = toggleGroup1.GetComponentsInChildren<Toggle>();
        var toggles2 = toggleGroup2.GetComponentsInChildren<Toggle>();
        
        //Find wich controls are selected
        int id = player1Controls();
        if (id < 0 || id >= 3) {
            return;
        }

    //    Debug.Log("--------------------------------");
    //    Debug.Log("id: "+ id);

        //IF same controls selected, change controls of player 2
        if (toggles1[id].isOn == toggles2[id].isOn){
            Debug.Log(" == ");
            toggles2[id].isOn = false;
            if (id < 2) {
                toggles2[id + 1].isOn = true;
            } else {
                toggles2[id - 1].isOn = true;
            }
        }
        toggles1[id].isOn = true;
    }

    public void WriteToPManager(){
        //Debug.Log("test");
        PersistentManagerScript.Instance.gameTime = gameTimer.value;
        PersistentManagerScript.Instance.p1Controls = (InputKeyboard) player1Controls();
        PersistentManagerScript.Instance.p2Controls = (InputKeyboard) player2Controls();
        PersistentManagerScript.Instance.initialColor1 = new Color(R1.value,G1.value, B1.value);
    }



}
