using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //public  List<GameObject> objects = new List<GameObject>();
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
    }

    public void setActivated(bool activated)
    {
        this.activated = activated;
    }

    public bool getActivated()
    {
        return activated;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clone") 
            other.gameObject.GetComponent<ActionScript>().setButton (transform.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Clone") 
            other.gameObject.GetComponent<ActionScript>().deleteButton();
    }

}
