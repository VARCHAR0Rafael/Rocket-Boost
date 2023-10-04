using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitaplicationScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Quit();
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
