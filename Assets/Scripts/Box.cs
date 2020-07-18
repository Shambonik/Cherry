using System.Collections;
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

        //if(isActivity && Input.GetKeyUp("e") && !isTaked){
        //    isTaked = true;
        //    boxtaker.GetComponent<BoxCollider2D>().enabled = true;
        //    transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        //} else {
        //    if(Input.GetKeyUp("e") && isTaked){
        //        isTaked = false;
        //        boxtaker.GetComponent<BoxCollider2D>().enabled = false;
        //        transform.parent.GetComponent<BoxCollider2D>().enabled = true;
        //        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        //    }
        //}


        if(isTaken)
        {
            transform.parent.position = boxtaker.position;
        }
    }

    public void setTaken(bool taken)
    {
        isTaken = taken;
    }

    public bool getTaken()
    {
        return isTaken;
    }

    public void setBoxtaker(Transform taker)
    {
        boxtaker = taker;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Clone")
        {
            cosmonaut = other.gameObject.GetComponent<ActionScript>();
            if (cosmonaut.getBox() == null)
            {
                cosmonaut.setBox(transform.gameObject);
            }
            //isActivity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "Clone") && !isTaken)
        {
            cosmonaut.deleteBox();
            boxtaker = null;
            cosmonaut = null;
            //isActivity = false;
        }
    }
}
