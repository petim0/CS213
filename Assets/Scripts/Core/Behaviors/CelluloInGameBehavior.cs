using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelluloInGameBehavior : AgentBehaviour
{

    public CelluloAgent agent; //mis en public pour quil puisse etre accessed par launchGameCellulo
    private Cellulo robot;
    public bool playerConnected;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<CelluloAgent>();
        robot = agent._celluloRobot;
        playerConnected = false;

        if(agent==null){
            Debug.LogWarning("An active CelluloAgent should be attached to the same gameobject.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(this.tag == "sheep"){
            OnCelluloSheep();
        }else if (this.tag == "ghost"){

        }
    }

    public override void OnCelluloLongTouch(int key){
        //passer le booléen à true pour que launchGameCellulos sache que le joueur est pret
       playerConnected = true;
       agent.ClearHapticFeedback(); //reset le robot avant de commencer le jeu si jamais
                                    //il a toujours les paramétrages d'une ancienne partie
    }


    
    public override void OnCelluloGhost(){
             agent.MoveOnStone();
    }

    public override void OnCelluloSheep(){
        // agent.ResetOnClick(); //on doit reset pour enlever le moveOnStone ?
        agent.ClearHapticFeedback();
        agent.SetCasualBackdriveAssistEnabled(true);
    }

    public bool isPlayerConnected(){
        return this.playerConnected;
    }

}
