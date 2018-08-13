using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain7 : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject tag;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        this.transform.position = cursorPosition;
        tag.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        if (tag == null)
        {
            tag = GameObject.Find("rainTag");
        }
        tag.SetActive(false);

    }

    void OnMouseUp()
    {
        tag.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
