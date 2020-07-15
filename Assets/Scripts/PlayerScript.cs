using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MoveScript moveScript;
    private List<bool> buttons;
    private List<List<bool>> history;
    public GameObject copy;
    private Vector2 startPosition;
    
    void Start()
    {
        moveScript = transform.GetComponent<MoveScript>();
        history = new List<List<bool>>();
        startPosition = transform.position;
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
        buttons = new List<bool> { Input.GetKey("d"), Input.GetKey("a"), Input.GetKey(KeyCode.Space) };
        history.Add(buttons);
        moveScript.action(buttons);
    }

    void Update()
    {
        if (Input.GetKeyUp("c"))
        {
            GameObject clone = Instantiate(copy);
            clone.GetComponent<CloneScript>().setHistory(history);
            clone.transform.position = startPosition;
        }
    }
}
