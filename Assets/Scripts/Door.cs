using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private float speed = 5f;
    private float shiftUp = 2f;
    private Vector2 closePosition;
    private Vector2 openPosition;

    private void Start() {
        closePosition = new Vector2(transform.position.x, transform.position.y);
        openPosition = new Vector2(transform.position.x, transform.position.y + shiftUp);
    }
    private void Update() {
        if(isOpen)
        {
            transform.position = Vector2.Lerp(transform.position, openPosition, speed * Time.deltaTime);
        } else {
            transform.position = Vector2.Lerp(transform.position, closePosition, speed * Time.deltaTime);
        }
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position - transform.up - new Vector3(0 , 0.2f), Vector2.down, 2f);
        Debug.DrawLine(transform.position - transform.up - new Vector3(0 , 0.2f), transform.position - transform.up - new Vector3(0 , 2.2f), Color.yellow);
        if(isOpen == true && hit)
        {   
            
            Debug.Log(hit.distance + " " + hit.collider);
        }*/
    }

    public void Action()
    {
        // if(isOpen == true && Physics2D.Raycast(transform.position, Vector2.down, shiftUp))
        // {
            
        // }
        isOpen = !isOpen;
    }
}
