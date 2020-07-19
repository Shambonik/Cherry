using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLevel : MonoBehaviour
{
    public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(level);
    }
}
