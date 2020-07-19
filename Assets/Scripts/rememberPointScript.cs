using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rememberPointScript : MonoBehaviour
{
    int i = 0;
    RememberObject rememberObject;


    private void Start()
    {
        Debug.Log("Вообще-то я работаю");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (i == 0)
            {
                other.GetComponent<PlayerScript>().startRemember();
                foreach (CloneScript cloneScript in (CloneScript[])Resources.FindObjectsOfTypeAll<CloneScript>())
                {
                    cloneScript.remember();
                }
                foreach (Transform tr in GameObject.Find("Objects").GetComponentsInChildren<Transform>())
                {
                    rememberObject = tr.GetComponent<RememberObject>();
                    if (rememberObject != null) rememberObject.set();
                }
            }
            i++;
        }
    }

    public void restart()
    {
        i = 0;

        foreach (CloneScript cloneScript in (CloneScript[])Resources.FindObjectsOfTypeAll<CloneScript>())
        {
            cloneScript.transform.gameObject.SetActive(true);
            cloneScript.restart();
        }
        foreach (Transform tr in GameObject.Find("Objects").GetComponentsInChildren<Transform>())
        {
            rememberObject = tr.GetComponent<RememberObject>();
            if (rememberObject != null) rememberObject.restart();
        }
    }


}
