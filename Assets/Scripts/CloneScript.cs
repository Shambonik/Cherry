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
    // Start is called before the first frame update
    void Start()
    {
        actionScript = transform.GetComponent<ActionScript>();
        iteration = 0;
        if (history == null) history = new List<HistoryElement>();
        checkCollidersScript = GetComponentInChildren<CheckCollidersScript>();
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
                    if (errors > 1) Debug.Log("МИР СЛОМАЛСЯ");
                    else errors++;
                }
                else errors = 0;
                transform.position = historyMoment.getPosition();
                if (historyMoment.getF())
                {
                    Debug.Log("HERE");
                    actionScript.action();
                }
                iteration++;
            }
            else Destroy(transform.gameObject);
        }
    }

    public void setHistory(List<HistoryElement> history)
    {
        this.history = new List<HistoryElement>(history);
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

                Debug.Log(coll);
                return false;
            }
        }
        return true;
    }

}
