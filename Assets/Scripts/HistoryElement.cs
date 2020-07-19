using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HistoryElement
{
    private Vector3 position;
    private bool fPressed;
    private bool jump;
    private List<Collider2D> colliders;
    private Quaternion rotation;
    private bool running;

    public HistoryElement(Vector3 pos, Quaternion rot, bool f, bool jump, List<Collider2D> coll, bool run)
    {
        position = pos;
        rotation = rot;
        fPressed = f;
        colliders = coll;
        this.jump = jump;
        running = run;
    }

    public Vector3 getPosition()
    {
        return position;
    }

    public bool getRunning()
    {
        return running;
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