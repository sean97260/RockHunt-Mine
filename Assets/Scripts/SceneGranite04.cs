using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGranite04 : MonoBehaviour
{
    public GameObject FastForward1; // For the wind
    public GameObject FastForward2; // For the river
    float timer;
    float timer2;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        timer2 = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite pieces"))
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 2.5)
            {
                this.gameObject.GetComponent<Animator>().SetBool("sand", true);
                if (transform.position.x >= 29 && transform.position.x <= 33)
                {
                    GameObject.Find("EventManager").GetComponent<EventManager>().windUsed = true;
                    GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("windgone", true);
                }
                else if (transform.position.x >= 56 && transform.position.x <= 62.3)
                {
                    GameObject.Find("EventManager").GetComponent<EventManager>().waterUsed = true;
                    GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("watergone", true);
                }
            }

        }
        else
        {
            timer2 = 0f;
        }

        if ((FastForward1 == null || FastForward1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress"))
            && transform.position.x >= 29 && transform.position.x <= 33)
        {
            print(timer);
            timer += Time.deltaTime;

            if (timer >= 2.5)
            {
                timer = 0f;
                this.gameObject.GetComponent<Animator>().SetBool("transform", true);
            }
        }

        if ((FastForward2 == null || FastForward2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress"))
            && transform.position.x >= 56 && transform.position.x <= 62.3)
        {
            timer += Time.deltaTime;

            if (timer >= 2.5)
            {
                timer = 0f;
                this.gameObject.GetComponent<Animator>().SetBool("transform", true);
            }
        }

        // Prevent the character from interacting during Fast Forward or when the granite is in pieces.
        if (FastForward1 != null)
        {
            if (FastForward1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress")
                || this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite pieces")
                || this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Transform"))
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Character").GetComponent<Collider2D>());
            }
            else
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Character").GetComponent<Collider2D>(), false);
            }
        }
        if (FastForward2 != null)
        {
            if (FastForward2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress")
                || this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite pieces")
                || this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Transform"))
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Character").GetComponent<Collider2D>());
            }
            else
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Character").GetComponent<Collider2D>(), false);
            }
        }

        GameObject cloud = GameObject.Find("Cloud");

        if (cloud != null && cloud.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rain")
            && cloud.transform.position.x - 2 <= this.transform.position.x && cloud.transform.position.x + 2 >= this.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("transform", true);
        }

    }
}
