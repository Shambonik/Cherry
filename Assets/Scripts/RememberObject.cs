using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberObject : MonoBehaviour
{

    private Vector2 position;
    private Quaternion rotation;
    private bool activated;

    Transform boxtaker;

    public void set()
    {
        position = transform.position;
        rotation = transform.rotation;
        switch (transform.tag)
        {
            case "Button":
                activated = GetComponent<Button>().getActivated();
                break;
            case "Door":
                activated = GetComponent<Door>().getIsOpen();
                break;
            case "Plate":
                GetComponent<Plate>().remember();
                break;
            case "Box":
                activated = GetComponentInChildren<Box>().getTaken();
                boxtaker = GetComponentInChildren<Box>().getBoxtaker();
                break;
        }
        
    }

    public void restart()
    {
        transform.position = position;
        transform.rotation = rotation;
        switch (transform.tag)
        {
            case "Button":
                GetComponent<Button>().setActivated(activated);
                break;
            case "Door":
                GetComponent<Door>().setIsOpen(activated);
                break;
            case "Plate":
                GetComponent<Plate>().restart();
                break;
            case "Box":
                GetComponentInChildren<Box>().setTaken(activated);
                GetComponentInChildren<Box>().setBoxtaker(boxtaker);
                GetComponent<Rigidbody2D>().freezeRotation = activated;
                GetComponent<BoxCollider2D>().enabled = !activated;
                break;
        }
    }
}
