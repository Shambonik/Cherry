using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private ActionScript actionScript;
    //private List<bool> history;
    public GameObject copy;
    private Vector3 startPosition;
    private bool fPrevious = false;
    private List<HistoryElement> history;

    private Transform cosmonaut;
    private Vector2 run = new Vector2(0.1f, 0);
    private bool isGrounded;
    private Rigidbody2D rb;
    private float jumpForce = 12;
    private CheckGroundedScript checkGrounded;
    private CheckCollidersScript checkCollidersScript;
    private bool remembering = false;
    private rememberPointScript remPoint;
    

    void Start()
    {
        cosmonaut = transform.Find("cosmonaut").transform;
        actionScript = transform.GetComponent<ActionScript>();
        history = new List<HistoryElement>();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        checkGrounded = GetComponentInChildren<CheckGroundedScript>();
        checkCollidersScript = GetComponentInChildren<CheckCollidersScript>();
        remPoint = GameObject.FindGameObjectWithTag("RememberPoint").GetComponent<rememberPointScript>();
    }

    void FixedUpdate()
    {
        //buttons = new List<bool> { , ,  };
        //history.Add(buttons);
        //action(buttons);

        isGrounded = checkGrounded.check();
        if(remembering) history.Add(new HistoryElement(transform.position, cosmonaut.rotation, (Input.GetKey("f") && !fPrevious), !(Mathf.Abs(rb.velocity.y)<0.5f), new List<Collider2D>(checkCollidersScript.getColliders())));
        if (Input.GetKey("d")) {
            cosmonaut.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(run);
        } else {
            if (Input.GetKey("a"))
            {
                cosmonaut.rotation = Quaternion.Euler(0f, 180f, 0f);
                transform.Translate(-run);
            } else {
                if (Input.GetKey("f"))
                {
                    if(!fPrevious) actionScript.action();
                    fPrevious = true;
                }
            }
        }

        if (!Input.GetKey("f")) fPrevious = false;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    public void startRemember()
    {
        remembering = true;
    }

    void Update()
    {
        if (Input.GetKeyUp("c"))
        {
            if (remembering)
            {
                GameObject clone = Instantiate(copy);
                clone.GetComponent<CloneScript>().setHistory(history);
                //clone.transform.position = startPosition;
                actionScript.setBoxtakerEnabled(false);
                transform.position = startPosition;
                remembering = false;
                history = new List<HistoryElement>();
                remPoint.restart();
            }
            else Debug.Log("Перемещение во времени запрещено");
        }
    }
}
