using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    private Vector2 run = new Vector2(0.12f,0);
    private RaycastHit2D hit;
    private bool isGrounded;
    private Rigidbody2D rb;
    private float jumpForce = 12;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*
     * 0 - d
     * 1 - a
     * 2 - space
     * 3 - e
     * 4 - left mouse button 
     */

    public void action(List<bool> buttons)
    {
        hit = Physics2D.Raycast(transform.position, /*-Vector2.up*/ Vector2.down, 1.05f);
        isGrounded = (hit.transform != null)&&(rb.velocity.y<=0);
        if (buttons[0]) transform.Translate(run);
        else if (buttons[1]) transform.Translate(-run);

        if (buttons[2] && isGrounded)
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
