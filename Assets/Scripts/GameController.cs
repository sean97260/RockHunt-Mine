using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{

    public GameObject[] selecRocks = { null , null};
    public GameObject[] selecTools = { null, null};
    public GameObject[] allRocks;
    public GameObject[] allTools;

    public int indexSR = 0;
    public int indexST = 0;

    private bool selectionMade = false;

    public GameObject actionButton;
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        allRocks = GameObject.FindGameObjectsWithTag("Rock");
        allTools = GameObject.FindGameObjectsWithTag("Tool");
    }

    public void ClearTools() {
        indexST = 0;
        foreach (GameObject obj in selecTools) {
            if (obj != null)
            {
                obj.GetComponent<ItemScript>().IsSelected = false;
            }
        }
    }

    public void ClearRocks() {
        indexSR = 0;
        foreach (GameObject obj in selecRocks)
        {
            if (obj != null)
            {
                obj.GetComponent<ItemScript>().IsSelected = false;
            }
        }
        selectionMade = false;
    }

    void FindSelected() {
        indexSR = 0;
        indexST = 0;
        foreach (GameObject currObj in allRocks)
        {
            bool selected = currObj.GetComponent<ItemScript>().IsSelected;
            if (selected && currObj.GetComponent<ItemScript>().IsFound)
            {
                selecRocks[indexSR] = currObj;
                indexSR++;
             
                if (indexSR > 2) {
                    ClearRocks();
                }
            }
        }
        foreach (GameObject currObj in allTools)
        {
            bool selected = currObj.GetComponent<ItemScript>().IsSelected;
            if (selected && currObj.GetComponent<ItemScript>().IsFound)
            {
                selecTools[indexST] = currObj;
                indexST++;
                if (indexST > 2)
                {
                    ClearTools();
                }
            }
        }
        if (indexSR == 1 && indexST == 1)
        {
            selectionMade = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject granite = GameObject.Find("Granite");
        if (granite != null && granite.GetComponent<ItemScript>().IsSelected)
        {
            obj.SetActive(true);
        }

   /*     if (!selectionMade)
        {
            FindSelected();
        }
        else if (selectionMade)
        {
            AllowAction();
        }*/
    }

    void AllowAction()
    {
        actionButton.SetActive(true);
    }

}
