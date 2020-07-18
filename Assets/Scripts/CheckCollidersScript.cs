using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollidersScript : MonoBehaviour
{
    private List<Collider2D> colliders;
    private Vector3 rotation = new Vector3(0, 0, 45);
    private List<string> BlockTags = new List<string> { "Blocks", "Door" };
    // Start is called before the first frame update
    void Start()
    {
    }

    public List<Collider2D> getColliders()
    {
        colliders = new List<Collider2D>();
        for(int i = 0; i<8; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, 3f);
            Debug.DrawRay(transform.position, transform.up, Color.red);
            for (int j = 0; j < hits.Length; j++)
            {
                if (!BlockTags.Contains(hits[j].collider.tag))
                {
                    if ((hits[j].collider.tag != transform.parent.tag) && (!colliders.Contains(hits[j].collider))) colliders.Add(hits[j].collider);
                }
                else break;
            }
            transform.Rotate(rotation);
        }
        return colliders;
    }

    //// Update is called once per frame
    //public List<Collider2D> getColliders()
    //{
    //    return colliders;
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (!colliders.Contains(other) && other.transform!=transform.parent && other.tag!= "CheckGrounded") colliders.Add(other);
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (colliders.Contains(other)) colliders.Remove(other);
    //}
   
}
