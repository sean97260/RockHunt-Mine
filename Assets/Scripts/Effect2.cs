using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect2 : MonoBehaviour
{

    GameObject obj;
    public GameObject wind;
    public GameObject fire;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fire")) {
            fire.SetActive(true);
        }
        if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Wind"))
        {
            wind.SetActive(true);
        }
        if (GameObject.Find("SceneGranite") != null)
        {
            if (GameObject.Find("SceneGranite").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("destroy"))
            {
                obj.SetActive(true);
                GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("granite", true);
            }

        }
    }
}
