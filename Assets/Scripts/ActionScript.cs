﻿using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{

    private Vector2 run = new Vector2(0.12f,0);
    //private RaycastHit2D hit;
    private Rigidbody2D rb;
    private CheckGroundedScript checkGrounded;
    private GameObject button;
    private GameObject box;
    private Transform boxtaker;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGrounded = GetComponentInChildren<CheckGroundedScript>();
        button = null;
        boxtaker = transform.Find("cosmonaut").Find("boxtaker");
    }

    /*
     * 0 - f
     * 1 - e
     */
     public void action()
     {
        Debug.Log("Action");
        if (box != null)
        {
            Debug.Log("Box");
            if (!box.GetComponent<Box>().getTaken())
            {
                boxtaker.GetComponent<BoxCollider2D>().enabled = true;
                box.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                box.GetComponent<Box>().setBoxtaker(boxtaker);
                box.GetComponent<Box>().setTaken(true);
                box.GetComponent<BoxCollider2D>().enabled = false;
                box.GetComponentInParent<Rigidbody2D>().SetRotation(0);
                box.GetComponentInParent<Rigidbody2D>().freezeRotation = true;
            }
            else
            {
                throwBox();
            }
        }
        else if (button != null)
        {
            button.GetComponent<Button>().setActivated(!button.GetComponent<Button>().getActivated());
        }
     }

    public void setButton(GameObject button)
    {
        this.button = button;
    }

    public void setBoxtakerEnabled(bool en)
    {
        boxtaker.GetComponent<BoxCollider2D>().enabled = en;
    }

    public Transform getBoxtaker()
    {
        return boxtaker;
    }

    public void deleteButton()
    {
        button = null;
    }

    public void setBox(GameObject box)
    {
        this.box = box;
    }

    public GameObject getBox()
    {
        return box;
    }

    public void deleteBox()
    {
        box = null;
    }


    public void throwBox()
    {
        boxtaker.GetComponent<BoxCollider2D>().enabled = false;
        if (box != null)
        {
            box.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
            box.GetComponent<Box>().setBoxtaker(null);
            box.GetComponent<Box>().setTaken(false);
            box.GetComponent<BoxCollider2D>().enabled = true;
            box.GetComponentInParent<Rigidbody2D>().freezeRotation = false;
            box.GetComponent<Box>().rigidbodySetDynamic();
        }
    }

}
