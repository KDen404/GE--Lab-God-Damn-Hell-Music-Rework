using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRotation : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePosition;

    private void Start()
    {

    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, angle - 90, 0));
    }
}
