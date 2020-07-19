using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollidersScript : MonoBehaviour
{
    private List<Collider2D> colliders;
    private Vector3 rotation = new Vector3(0, 0, 30);
    private List<string> BlockTags = new List<string> { "Blocks", "Door" };
    private float len = 2.5f;
    private Collider2D cosmonautCollider;
    // Start is called before the first frame update
    void Start()
    {
        cosmonautCollider = transform.parent.parent.GetComponent<Collider2D>();
    }

    public List<Collider2D> getColliders()
    {
        colliders = new List<Collider2D>();
        for(int i = 0; i<12; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, len);
            Debug.DrawRay(transform.position, transform.up, Color.red);
            for (int j = 0; j < hits.Length; j++)
            {
                if (!BlockTags.Contains(hits[j].collider.tag))
                {
                    if ((hits[j].collider != cosmonautCollider) && (hits[j].collider.transform.parent == null || (hits[j].collider.transform.parent != transform.parent)) && (!colliders.Contains(hits[j].collider))) colliders.Add(hits[j].collider);
                }
                else
                {
                    if (!colliders.Contains(hits[j].collider)) colliders.Add(hits[j].collider);
                    break;
                }
            }
            transform.Rotate(rotation);
        }
        return colliders;
    }
   
}
