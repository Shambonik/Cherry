using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private List<List<bool>> history;
    private int iteration;
    private MoveScript moveScript;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = transform.GetComponent<MoveScript>();
        newPosition = transform.position;
        iteration = 0;
        if (history == null) history = new List<List<bool>>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.6f);
        if (history.Count != 0)
        {
            Debug.Log(history.Count);
            if (iteration < history.Count) newPosition = moveScript.action(history[iteration++]);
            else Destroy(transform.gameObject);
        }
    }

    public void setHistory(List<List<bool>> history)
    {
        this.history = new List<List<bool>>(history);
    }
}
