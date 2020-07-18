using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBox : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool isCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity == Vector2.zero && isCollision)
        {
            rigidbody.bodyType = RigidbodyType2D.Static;
        } else {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Clone")
        {
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Clone")
        {
            isCollision = false;
        }
    }
}
