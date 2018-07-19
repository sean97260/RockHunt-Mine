using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGranite02 : MonoBehaviour
{

    public GameObject obj;
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
        if ((GameObject.Find("bag").GetComponent<BagScript02>() && GameObject.Find("bag").GetComponent<BagScript02>().sandTransformed)
            ||( GameObject.Find("bag").GetComponent<BagScript03>() && GameObject.Find("bag").GetComponent<BagScript03>().sandTransformed)) {
            this.gameObject.GetComponent<Animator>().Play("SandShowUp");
        }
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite pieces"))
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 1)
            {
                this.gameObject.GetComponent<Animator>().SetBool("sand", true);
            }

        }
        else
        {
            timer2 = 0f;
        }

        GameObject cloud = GameObject.Find("Cloud");

        if (cloud != null && cloud.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rain")
            && cloud.transform.position.x - 2 <= this.transform.position.x && cloud.transform.position.x + 2 >= this.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("transform", true);
        }

    }
}
