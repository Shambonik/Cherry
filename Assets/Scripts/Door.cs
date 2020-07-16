using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private float speed = 5f;
    private float shiftUp = 2f;
    private Vector2 closePosition;
    private Vector2 openPosition;
    ContactFilter2D contactFilter = new ContactFilter2D();
    List<RaycastHit2D> hits = new List<RaycastHit2D>();

    private void Start() 
    {
        closePosition = new Vector2(transform.position.x, transform.position.y);
        openPosition = new Vector2(transform.position.x, transform.position.y + shiftUp);
    }
    private void Update() 
    {
        if(isOpen)
        {
            transform.position = Vector2.Lerp(transform.position, openPosition, speed * Time.deltaTime);
        } else {
            transform.position = Vector2.Lerp(transform.position, closePosition, speed * Time.deltaTime);
        }
    }

    public void Action()
    {
        int hits = Physics2D.Raycast(transform.position - transform.up - new Vector3(0 , 0.01f),
                Vector2.down, contactFilter, this.hits, 1.5f);
        if(isOpen)
        {
            if(hits == 0)
            {
                isOpen = false;
            }
        } else {
            isOpen = true;
        }
        
    }
}
