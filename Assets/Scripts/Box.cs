using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isActivity = false;
    private GameObject cosmonaut;
    private Transform boxtaker;
    private Rigidbody2D rigidbody;

    bool isTaked = false;

    private void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(rigidbody.velocity == Vector2.zero && cosmonaut != null && !isTaked)
        {
            rigidbody.bodyType = RigidbodyType2D.Static;
        } else {
            if(isTaked)
            {
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
            } else {
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        if(isActivity && Input.GetKeyUp("e") && !isTaked){
            isTaked = true;
            boxtaker.GetComponent<BoxCollider2D>().enabled = true;
            transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        } else {
            if(Input.GetKeyUp("e") && isTaked){
                isTaked = false;
                boxtaker.GetComponent<BoxCollider2D>().enabled = false;
                transform.parent.GetComponent<BoxCollider2D>().enabled = true;
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if(isTaked){
            transform.parent.position = boxtaker.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Clone")
        {
            cosmonaut = other.gameObject;
            boxtaker = cosmonaut.transform.Find("boxtaker");
            isActivity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "Clone") && !isTaked)
        {
            boxtaker = null;
            cosmonaut = null;
            isActivity = false;
        }
    }
}
