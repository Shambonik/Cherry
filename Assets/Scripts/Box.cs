using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isActivity = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(isActivity && Input.GetKeyUp("e"))
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") isActivity = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player") isActivity = false;
    }
}
