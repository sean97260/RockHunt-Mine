using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaScript : MonoBehaviour
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
        if (timer >= 2.0f && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SceneMagma")){
            this.GetComponent<Animator>().SetBool("transform", true);
            timer = 0;
        } else if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SceneMagma")){
            timer += Time.deltaTime;
            this.GetComponent<Animator>().SetBool("returnMagma", false);

        }

        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("transform_m")){
            this.GetComponent<Animator>().SetBool("transform", false);
        }

    }
}