using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private MoveScript moveScript;
    private List<bool> buttons;
    private List<List<bool>> history;
    public GameObject copy;
    private bool allowRight = true;
    private bool allowLeft = true;
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
        buttons = new List<bool> { Input.GetKey("d") && allowRight, Input.GetKey("a") && allowLeft, Input.GetKey(KeyCode.Space) };
        history.Add(buttons);
        moveScript.action(buttons);
        if (Input.GetKeyDown("c"))
        {
            GameObject clone = Instantiate(copy);
            clone.GetComponent<CloneScript>().setHistory(history);
            clone.transform.position = startPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (Input.GetKey("d")) allowRight = false;
        else if(Input.GetKey("a")) allowLeft= false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        allowLeft = true;
        allowRight = true;
    }
}
