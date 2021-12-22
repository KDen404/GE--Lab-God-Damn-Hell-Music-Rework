using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject canvas;
    private void Start()
    {
        canvas = transform.Find("PauseMenuCanvas").gameObject;
        //transform.Find("PauseMenuCanvas").gameObject.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
