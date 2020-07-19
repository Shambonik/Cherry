using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3 : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;
    public GameObject door1;
    public GameObject door2;
    private bool door1Status = false;
    private bool door2Status = false;

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
        if (button2.GetComponent<Button>().getActivated() != door2Status)
        {
            door2.GetComponent<Door>().Action();
            door2Status = !door2Status;
        }
    }
}
