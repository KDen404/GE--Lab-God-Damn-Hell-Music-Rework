using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageProjectiles : MonoBehaviour
{
    public int projectileSpeed = 5;

    // Makes the projectile fly forward
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);
    }
}
