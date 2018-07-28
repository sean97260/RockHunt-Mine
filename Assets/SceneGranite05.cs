using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGranite05 : MonoBehaviour
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

        if (this.gameObject.GetComponent<Animator>() && 
            this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite pieces"))
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 7)
            {
                this.gameObject.GetComponent<Animator>().SetBool("sand", true);
                if (transform.position.x >= 29 && transform.position.x <= 33)
                {
                    GameObject.Find("EventManager").GetComponent<EventManager05>().windUsed = true;
                    GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("windgone", true);
                }
                else if (transform.position.x >= 56 && transform.position.x <= 62.3)
                {
                    GameObject.Find("EventManager").GetComponent<EventManager05>().waterUsed = true;
                    GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("watergone", true);
                }
            }

        }
        else
        {
            timer2 = 0f;
        }

        if (transform.position.x >= 29 && transform.position.x <= 33)
        {
            if (GameObject.Find("EventManager").GetComponent<EventManager05>().windUsed == false)
            {
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    timer = 0f;
                    this.gameObject.GetComponent<Animator>().SetBool("transform", true);
                }
            }
            else
            {
                timer = 0f;
            }
        }

        if (transform.position.x >= 56 && transform.position.x <= 62.3)
        {
            if (GameObject.Find("EventManager").GetComponent<EventManager05>().waterUsed == false)
            {
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    timer = 0f;
                    this.gameObject.GetComponent<Animator>().SetBool("transform", true);
                }
            }
            else
            {
                timer = 0f;
            }
        }


        if (this.gameObject.GetComponent<Animator>() && 
            this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
        {
            GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("gotSand", true);

        }

        if (FastForward1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress")){
            Debug.Log("Fast-forward in progress!");
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

    }
}
