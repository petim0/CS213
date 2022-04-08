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