using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    public float speed = 0.03f;
    private GameObject player;
    private GameObject target;
    private GameObject deathPanel;
    private bool death = false;
    private float startTime;
    private float durationDeath1 = 2f;
    private float durationDeath2 = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel.SetActive(false);
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!death)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), speed);
            if(Time.time - startTime > durationDeath1)
            {
                deathPanel.SetActive(true);
            }
            if(Time.time - startTime > durationDeath1+durationDeath2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void Death(GameObject target)
    {
        if (!death)
        {
            this.target = target;
            startTime = Time.time;
            death = true;
            player.GetComponent<PlayerScript>().enabled = false;
            target.GetComponent<CloneScript>().enabled = false;
            Debug.Log("СМЕРТЬ МИРА");
        }
    }
}
