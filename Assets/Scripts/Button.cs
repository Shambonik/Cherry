using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public  List<GameObject> objects = new List<GameObject>();
    private bool isActivity = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivity && Input.GetKeyUp("f"))
        {
            for(int i = 0; i < objects.Count; i++)
            {
                string tag = objects[i].gameObject.tag;
                switch(tag)
                {
                    case "Door":
                        objects[i].GetComponent<Door>().Action();
                        break;
                }
            }
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") isActivity = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player") isActivity = false;
    }
}
