using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundedScript : MonoBehaviour
{

    //private GameObject parent;

    List<Collider2D> TriggerList = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        //parent = transform.parent.gameObject;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(TriggerList.Count);
        if (!TriggerList.Contains(other)) TriggerList.Add(other);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (TriggerList.Contains(other)) TriggerList.Remove(other);
    }

    public bool check()
    {
        foreach (Collider2D collider in TriggerList)
        {
            if (collider.tag == "Blocks" || collider.tag == "Box") return true;
        }
        return false;
    }
}
