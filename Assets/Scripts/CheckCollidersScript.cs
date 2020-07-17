using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollidersScript : MonoBehaviour
{
    private List<Collider2D> colliders;
    // Start is called before the first frame update
    void Start()
    {
        colliders = new List<Collider2D>();
    }

    // Update is called once per frame
    public List<Collider2D> getColliders()
    {
        return colliders;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other) && other.transform!=transform.parent && other.tag!= "CheckGrounded") colliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (colliders.Contains(other)) colliders.Remove(other);
    }
   
}
