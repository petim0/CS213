using UnityEngine;
using System.Collections;
public class AgentBehaviour : MonoBehaviour
{
    public float weight = 1.0f;
    protected CelluloAgent agent;
    private Cellulo robot;


    public virtual void Awake()
    {
        agent = gameObject.GetComponent<CelluloAgent>();
        robot = agent._celluloRobot;

        if(agent==null){
            Debug.LogWarning("An active CelluloAgent should be attached to the same gameobject.");
        }
    }

    public virtual Steering GetSteering()
    {
        return new Steering();
    }

    /// <summary>
    /// Virtual function, to be implemented if OnTouchBegan from Real robot is needed
    /// </summary>
    /// <param name="key">
    /// the number of the key touch sensor 
    /// </param>
    public virtual void OnCelluloTouchBegan(int key){}
    /// <summary>
    /// Virtual function, to be implemented if OnTouchReleased from Real robot is needed
    /// </summary>
    /// <param name="key">
    /// the number of the key touch sensor 
    /// </param>
    public virtual void OnCelluloTouchReleased(int key){}
        /// <summary>
    /// Virtual function, to be implemented if OnLongTouch from Real robot is needed
    /// </summary>
    /// <param name="key">
    /// the number of the key touch sensor 
    /// </param>
    public virtual void OnCelluloLongTouch(int key){

       //TODO agent._celluloRobot.OnLongTouch;
       //subscribe to  _celluloRobot.OnLongTouch
    }
    
    /// <summary>
    /// Event signaled when robot kidnapping ends 
    /// </summary>
    public virtual void OnCelluloUnKidnapped(){}
    /// <summary>
    /// Event signaled when robot is kidnapped
    /// </summary>
    public virtual void OnCelluloKidnapped(){}

    public virtual void OnCelluloGhost(){
        if(this.tag == "dog"){
             agent.MoveOnStone();
        }
    }

    public virtual void OnCelluloSheep(){
        if(this.tag == "dog"){
           // agent.ResetOnClick(); //on doit reset pour enlever le moveOnStone ?
            robot.SetCasualBackdriveAssistEnabled(true);

        }
    }

}
