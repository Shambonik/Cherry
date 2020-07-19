using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    private float speed = 5f;
    private float shiftUp = 2f;
    private Vector2 closePosition;
    private Vector2 openPosition;
    ContactFilter2D contactFilter = new ContactFilter2D();
    List<RaycastHit2D> hits = new List<RaycastHit2D>();
    //Collider2D coll;

    private void Start() 
    {
        LayerMask layer = LayerMask.GetMask("Default"); 
        contactFilter.SetLayerMask(layer);
        closePosition = new Vector2(transform.position.x, transform.position.y);
        openPosition = new Vector2(transform.position.x, transform.position.y + shiftUp);
        //coll = transform.GetComponent<Collider2D>();
    }
    private void Update() 
    {
        if(isOpen)
        {
            transform.position = Vector2.Lerp(transform.position, openPosition, speed * Time.deltaTime);
            //coll.enabled = false;
        } else {
            int hits = Physics2D.Raycast(transform.position - transform.up - new Vector3(0, 0.01f),
                Vector2.down, contactFilter, this.hits, shiftUp);
            //coll.enabled = true;
            if (hits == 0)
            {
                transform.position = Vector2.Lerp(transform.position, closePosition, speed * Time.deltaTime);
            }
        }
    }

    public bool getIsOpen()
    {
        return isOpen;
    }

    public void setIsOpen(bool open)
    {
        isOpen = open;
    }

    public void Action()
    {
        isOpen = !isOpen;
    }
}
