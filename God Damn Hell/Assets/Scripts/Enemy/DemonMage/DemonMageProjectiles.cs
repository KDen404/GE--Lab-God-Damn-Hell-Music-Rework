using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageProjectiles : MonoBehaviour
{
    private Vector3 playerPosition;
    public int projectileSpeed = 5;

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //playerPosition.y = 1f;
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, playerPosition, projectileSpeed * Time.deltaTime);
        transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
    }
}
