using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granite02 : MonoBehaviour
{

    public GameObject obj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject cloud = GameObject.Find("Cloud");

        if (cloud != null && cloud.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rain") && cloud.transform.position.x - 10 <= this.transform.position.x && cloud.transform.position.x + 10 >= this.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("transform", true);
        }

        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
        {
            GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("gotSand", true);

        }

    }
}
