using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSandStoneScript : MonoBehaviour
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
        if(transform.position.x >= 22 && transform.position.x <= 29.8 && transform.position.y <= -21.2 && transform.position.x >= -23.3){
            this.GetComponent<Animator>().SetBool("transform", true);
            GameObject.Find("Transition").GetComponent<Animator>().SetTrigger("Metaquartzite");

        }
    }
}
