using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1 : MonoBehaviour
{

    public GameObject button1;
    public GameObject door1;
    private bool door1Status = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button1.GetComponent<Button>().getActivated() != door1Status)
        {
            door1.GetComponent<Door>().Action();
            door1Status = !door1Status;
        }
    }
}
