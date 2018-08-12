using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalN3_6 : MonoBehaviour
{

    GameObject character;
    GameObject camera;

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        camera = GameObject.Find("Main Camera");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cowboy")
        {
            character.transform.position = new Vector3(76.817f, -2.625f, 0);
            camera.transform.position = new Vector3(72.9629f, 0, -10f);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
