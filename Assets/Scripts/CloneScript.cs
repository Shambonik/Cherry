using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private List<List<bool>> history;
    private int iteration;
    private MoveScript moveScript;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = transform.GetComponent<MoveScript>();
        iteration = 0;
        if (history == null) history = new List<List<bool>>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (history.Count != 0)
        {
            if (iteration < history.Count) moveScript.action(history[iteration++]);
            else Destroy(transform.gameObject);
        }
    }

    public void setHistory(List<List<bool>> history)
    {
        this.history = new List<List<bool>>(history);
    }

}
