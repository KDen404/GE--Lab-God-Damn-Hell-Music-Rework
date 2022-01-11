using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageProjectiles : MonoBehaviour
{
    public int projectileSpeed = 5;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
    }
}
