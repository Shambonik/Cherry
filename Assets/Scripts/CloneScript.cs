using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private List<HistoryElement> history;
    private int iteration;
    private ActionScript actionScript;
    private HistoryElement historyMoment;
    private CheckCollidersScript checkCollidersScript;
    private int errors = 0;
    private int startIndex = 0;
    private CameraScript camera;
    Transform cosmonaut;

    private GameObject oldBox;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        actionScript = transform.GetComponent<ActionScript>();
        iteration = 0;
        if (history == null) history = new List<HistoryElement>();
        checkCollidersScript = GetComponentInChildren<CheckCollidersScript>();
        cosmonaut = transform.Find("cosmonaut").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (history.Count != 0)
        {
            if (iteration < history.Count)
            {
                historyMoment = history[iteration];
                if (!historyMoment.getJump() && !collidersAreSimilar())
                {
                    if (errors > 10) camera.Death(transform.gameObject);
                    else errors++;
                }
                else errors = 0;
                transform.position = historyMoment.getPosition();
                cosmonaut.rotation = historyMoment.getRotation();
                Debug.Log("Rot" + historyMoment.getRotation().eulerAngles);
                if (historyMoment.getF())
                {
                    actionScript.action();
                }
                iteration++;
            }
            else
            {
                if (actionScript.getBox() != null)
                {

                    actionScript.getBox().GetComponent<Box>().setTaken(false);
                    actionScript.getBox().GetComponent<Box>().setBoxtaker(null);
                    actionScript.getBox().GetComponentInParent<Rigidbody2D>().freezeRotation = false;
                    actionScript.getBox().transform.parent.GetComponent<BoxCollider2D>().enabled = true;
                    actionScript.setBoxtakerEnabled(false);
                    actionScript.deleteBox();
                }
                transform.gameObject.SetActive(false);
            }
        }
    }

    public void setHistory(List<HistoryElement> history)
    {
        this.history = new List<HistoryElement>(history);
    }


    public void remember()
    {
        if (actionScript != null)
        {
            oldBox = actionScript.getBox();
            startIndex = iteration;
        }
    }

    public void restart()
    {
        if ((startIndex>0)&&(startIndex >= history.Count))
        {
            Destroy(transform.gameObject);
        }
        iteration = startIndex;
        if (oldBox != null)
        {
            actionScript.setBox(oldBox);
            actionScript.getBox().GetComponent<Box>().setTaken(true);
            actionScript.getBox().GetComponent<Box>().setBoxtaker(actionScript.getBoxtaker());
            actionScript.getBox().GetComponentInParent<Rigidbody2D>().freezeRotation = true;
            actionScript.getBox().transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            actionScript.setBoxtakerEnabled(true);
        }
    }

    private bool collidersAreSimilar()
    {
        if (checkCollidersScript.getColliders().Count != historyMoment.getColliders().Count) {
            foreach(Collider2D coll in checkCollidersScript.getColliders())
            {
                Debug.Log(coll);
            }
            Debug.Log(checkCollidersScript.getColliders().Count + " : " + historyMoment.getColliders().Count);
            foreach (Collider2D coll in historyMoment.getColliders())
            {
                Debug.Log(coll);
            }
            return false;
        }
        foreach (Collider2D coll in checkCollidersScript.getColliders())
        {
            if (!historyMoment.getColliders().Contains(coll))
            {
                foreach (Collider2D colli in checkCollidersScript.getColliders())
                {
                    Debug.Log(colli);
                }
                Debug.Log(checkCollidersScript.getColliders().Count + " : " + historyMoment.getColliders().Count);
                foreach (Collider2D colli in historyMoment.getColliders())
                {
                    Debug.Log(colli);
                }
                //Debug.Log(coll);
                return false;
            }
        }
        return true;
    }

}
