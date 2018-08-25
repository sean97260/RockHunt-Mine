using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    bool activated = true;
    public string CurrentScene;
    GameObject DialogFirst;

    public string CurrentLevelName;

    // Use this for initialization
    void Start()
    {
        DialogFirst = GameObject.Find("DialogFirst");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLevelName = "N" + Map.CurrLevel.ToString();
        Debug.Log(CurrentLevelName);
        Debug.Log(this.name);
        if (this.name != CurrentLevelName)
        {
            this.GetComponent<Animator>().enabled = false;
        }
        else {
            this.GetComponent<Animator>().enabled = true;
        }
    }

    void OnMouseDown()
    {
        if (activated == true && GameObject.Find("DialogFirst") == null)
        {
            SceneManager.LoadScene(CurrentScene);
        }

    }
}
