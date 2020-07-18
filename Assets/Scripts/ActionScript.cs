using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{

    private Vector2 run = new Vector2(0.12f,0);
    //private RaycastHit2D hit;
    private Rigidbody2D rb;
    private CheckGroundedScript checkGrounded;
    private GameObject button;
    private GameObject box;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGrounded = GetComponentInChildren<CheckGroundedScript>();
        button = null;
    }

    /*
     * 0 - f
     * 1 - e
     */
     public void action()
     {
        if (button != null)
        {
            button.GetComponent<Button>().setActivated(!button.GetComponent<Button>().getActivated());
        }
        if (box != null)
        {

        }
     }

    public void setButton(GameObject button)
    {
        this.button = button;
    }

    public void deleteButton()
    {
        button = null;
    }
   
}
