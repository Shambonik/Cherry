using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public  List<GameObject> objects = new List<GameObject>();
    private int countObjectsInButton = 0;
    private int lastCountObjectsInButton = 0;
   
    void Update()
    {
        if(countObjectsInButton > 0)
        {
            if(lastCountObjectsInButton == 0) Action();
        } else {
            if(lastCountObjectsInButton != countObjectsInButton) Action(); 
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        countObjectsInButton++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        countObjectsInButton--;
    }

    private void Action(){
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
        lastCountObjectsInButton = countObjectsInButton;
    }
}
