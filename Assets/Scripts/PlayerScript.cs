using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MoveScript moveScript;
    private List<bool> buttons;
    private Vector3 newPosition;
    private List<List<bool>> history;
    public GameObject copy;

    
    void Start()
    {
        moveScript = transform.GetComponent<MoveScript>();
        newPosition = transform.position;
        history = new List<List<bool>>();
    }

    /*
    * 0 - d
    * 1 - a
    * 2 - space
    * 3 - e
    * 4 - left mouse button 
    */

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
        buttons = new List<bool> { Input.GetKey("d"), Input.GetKey("a"), Input.GetKey(KeyCode.Space)};
        history.Add(buttons);
        newPosition = moveScript.action(buttons);
        if (Input.GetKeyDown("c"))
        {
            GameObject clone = Instantiate(copy);
            clone.GetComponent<CloneScript>().setHistory(history);
        }
    }
}
