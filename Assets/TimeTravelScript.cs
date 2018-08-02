using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelScript : MonoBehaviour {

    public int numFF; // How many FastForward objects?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < numFF; i++)
        {
            GameObject FF = FindFF(i);
            if (FF != null)
            {
                if (FF.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FFInProgress"))
                {
                    this.GetComponent<Animator>().SetTrigger("PlayTimeTravel");
                }
                if (FF.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End")) {
                    this.GetComponent<Animator>().ResetTrigger("PlayTimeTravel");
                }
            }
        }
    }

    // Find FastForward obj
    GameObject FindFF(int i)
    {
        if (i == 0)
        {
            return GameObject.Find("FastForward");
        }
        else
        {
            string name = "FastForward (" + i.ToString() + ")";
            return GameObject.Find(name);
        }
    }
}
