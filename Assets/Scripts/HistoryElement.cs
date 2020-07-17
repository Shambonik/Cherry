using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HistoryElement
{
    private Vector2 position;
    private bool fPressed;
    private bool jump;
    private List<Collider2D> colliders;

    public HistoryElement(Vector2 pos, bool f, bool jump, List<Collider2D> coll)
    {
        position = pos;
        fPressed = f;
        colliders = coll;
        this.jump = jump;
    }

    public Vector2 getPosition()
    {
        return position;
    }

    public bool getF()
    {
        return fPressed;
    }

    public List<Collider2D> getColliders()
    {
        return colliders;
    }

    public bool getJump()
    {
        return jump;
    }
}