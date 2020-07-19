using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //public  List<GameObject> objects = new List<GameObject>();
    private bool activated = false;
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").gameObject;
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
        string tag = other.gameObject.tag;
        if (tag == "Player" || tag == "Clone")
        {
            if(tag == "Player") text.SetActive(true);
            other.gameObject.GetComponent<ActionScript>().setButton (transform.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Player" || tag == "Clone")
        {
            if(tag == "Player") text.SetActive(false);
            other.gameObject.GetComponent<ActionScript>().deleteButton();
        } 
            
    }

}
