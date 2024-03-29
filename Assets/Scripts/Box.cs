﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //private bool isActivity = false;
    private ActionScript cosmonaut;
    private Transform boxtaker;
    private Rigidbody2D rigidbody;

    bool isTaken = false;

    private void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(rigidbody.velocity == Vector2.zero && cosmonaut != null && !isTaken)
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        } else {
            if(isTaken)
            {
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
            } else {
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        if(isTaken)
        {
            transform.parent.position = boxtaker.position;
        }
    }

    public void rigidbodySetDynamic()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void setTaken(bool taken)
    {
        isTaken = taken;
    }

    public bool getTaken()
    {
        return isTaken;
    }

    public Transform getBoxtaker()
    {
        return boxtaker;
    }

    public void setBoxtaker(Transform taker)
    {
        boxtaker = taker;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(!isTaken)Debug.Log(other.gameObject + " enter");
        if (!isTaken)
        {
            string tag = other.gameObject.tag;
            if (tag == "Player" || tag == "Clone")
            {
                cosmonaut = other.gameObject.GetComponent<ActionScript>();
                if(tag == "Player") cosmonaut.transform.Find("Text").gameObject.SetActive(true);
                if (cosmonaut.getBox() == null)
                {
                    cosmonaut.setBox(transform.gameObject);
                }
                //isActivity = true;
            }
            else
            {
                if (tag == "Boxtaker")
                {
                    cosmonaut = other.GetComponentInParent<ActionScript>();
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if (!isTaken)
        {
            string tag = other.gameObject.tag;
            if ((tag == "Player" || tag == "Clone" || tag == "Boxtaker") && !isTaken)
            {
                if(tag == "Player") cosmonaut.transform.Find("Text").gameObject.SetActive(false);
                if ((cosmonaut != null) && (cosmonaut.getBox() == transform.gameObject)) cosmonaut.deleteBox();
                boxtaker = null;
                cosmonaut = null;
                //isActivity = false;
            }
        }
    }
}
