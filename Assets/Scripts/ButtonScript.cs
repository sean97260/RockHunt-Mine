using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, ISelectHandler{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelect(BaseEventData eventData)
    {
        // Get variables from GameController
      //  GameObject[] allRocks = (GameObject.Find("Controller")).GetComponent<GameController>().allRocks;
       // GameObject[] allTools = (GameObject.Find("Controller")).GetComponent<GameController>().allTools;
        GameObject[] selecRocks = (GameObject.Find("Controller")).GetComponent<GameController>().selecRocks;
        GameObject[] selecTools = (GameObject.Find("Controller")).GetComponent<GameController>().selecTools;
        int indexSR = (GameObject.Find("Controller")).GetComponent<GameController>().indexSR;
        int indexST = (GameObject.Find("Controller")).GetComponent<GameController>().indexST;
//        GameObject sand = null;

        for (int i = 0; i < indexSR; i++)
        {
            if (selecRocks[i].name == "Granite")
            {
                for (int j = 0; j < indexST; j++)
                {
                    if (selecTools[j].name == "Rain")
                    {
                        GameObject.Find("Sand").GetComponent<ItemScript>().IsFound = true;

                        GameObject.Find("Controller").GetComponent<GameController>().ClearRocks();
                        GameObject.Find("Controller").GetComponent<GameController>().ClearTools();
                        return;
                    }
                }
            }
        }
    }
}
