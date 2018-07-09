using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cowboy")
        {
            if (Map.CurrLevel <= 1 && SceneManager.GetActiveScene().name == "Level01")
            {
                Map.CurrLevel = 2;
            }
            else if (Map.CurrLevel <= 2 && SceneManager.GetActiveScene().name == "Level02")
            {
                Map.CurrLevel = 3;
            }
            else if (Map.CurrLevel <= 3 && SceneManager.GetActiveScene().name == "Level03")
            {
                Map.CurrLevel = 4;
            }
            else if (Map.CurrLevel <= 4 && SceneManager.GetActiveScene().name == "Level04")
            {
                Map.CurrLevel = 5;
            }
            SceneManager.LoadScene("Map");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
