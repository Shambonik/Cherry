using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HistoryElement
{
    private Vector2 position;
    private bool fPressed;
    private bool jump;
    private List<Collider2D> colliders;
    private Quaternion rotation;

    public HistoryElement(Vector2 pos, Quaternion rot, bool f, bool jump, List<Collider2D> coll)
    {
        position = pos;
        rotation = rot;
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

    public Quaternion getRotation()
    {
        return rotation;
    }
}