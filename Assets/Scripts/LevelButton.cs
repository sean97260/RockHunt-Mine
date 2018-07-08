using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    bool activated = true;
    public string CurrentScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (activated == true)
        {
            SceneManager.LoadScene(CurrentScene);
        }

    }
}
