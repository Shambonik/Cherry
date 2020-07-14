using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    private Vector3 run = new Vector3(0.2f,0,0);
    private Vector3 position;
    private RaycastHit hit;
    private float ySpeed = 0;

    /*
     * 0 - d
     * 1 - a
     * 2 - space
     * 3 - e
     * 4 - left mouse button 
     */

    public Vector3 action(List<bool> buttons)
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f)) ySpeed -= 0.05f;
        else if(ySpeed<0) ySpeed = 0;
        if ((buttons[2]) && (ySpeed == 0)) ySpeed = 0.7f; 
        position = transform.position + new Vector3(0, ySpeed, 0);
        if (buttons[0])
        {
            position = position + run;
        }
        else if (buttons[1])
        {
            position = position - run;
        }
        return position;
    }
}
