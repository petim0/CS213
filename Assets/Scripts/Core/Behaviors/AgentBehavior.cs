using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public float weight = 1.0f;
    protected CelluloAgent agent;

    public GameObject[] sheeps;
    public GameObject[] players;

    const int minNumberPlayer = 2;


    public void Start()
    {
        //Set the tag of this GameObject to Player
        gameObject.tag = "Player";
        sheeps = GameObject.FindGameObjectsWithTag("Sheep");
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if (players.Length < minNumberPlayer) {
            Debug.Log("Not enough Players to start the Game, don't you have friends?");
        }
    }


    public virtual void Awake()
    {
        agent = gameObject.GetComponent<CelluloAgent>();
    }
    public virtual void FixedUpdate()
    {
        if (agent.blendWeight)
            agent.SetSteering(GetSteering(), weight);
        else
            agent.SetSteering(GetSteering());
    }
    public virtual Steering GetSteering()
    {
        return new Steering();
    }
}
