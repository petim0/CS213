using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows = 0, 
    wasd = 1
}
public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public InputKeyboard inputKeyboard; 

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        //implement your code here
        if (inputKeyboard == 0)
        {
            steering.linear = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }
        else {
            steering.linear = new Vector3(Input.GetAxis("HorizontalWASD"), 0, Input.GetAxis("VerticalWASD")) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }
        return steering;
    }

}
