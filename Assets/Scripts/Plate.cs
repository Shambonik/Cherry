using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public  List<GameObject> objects = new List<GameObject>();
    private int countObjectsInButton = 0;
    private int lastCountObjectsInButton = 0;

    private int countObjectsInButtonRem;
    private int lastCountObjectsInButtonRem;


    void Update()
    {
        if (countObjectsInButton > 0)
        {
            if(lastCountObjectsInButton == 0) Action();
        } else {
            if(lastCountObjectsInButton != countObjectsInButton) Action(); 
        }
        Debug.Log("Plate " + countObjectsInButton);
    }

    public void remember()
    {
        countObjectsInButtonRem = countObjectsInButton;
        lastCountObjectsInButtonRem = lastCountObjectsInButton;
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.tag != "CheckColliders")
        countObjectsInButton = Mathf.Min(countObjectsInButton+1, 3);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.tag != "CheckColliders" && 
        if(countObjectsInButton>0) countObjectsInButton--;
    }

    public void restart()
    {
        countObjectsInButton = countObjectsInButtonRem;
        lastCountObjectsInButton = lastCountObjectsInButtonRem;
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
